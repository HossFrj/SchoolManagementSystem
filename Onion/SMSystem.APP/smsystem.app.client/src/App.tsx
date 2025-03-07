"use client";

import { useState, useEffect } from "react";
import { Table, Button, Group, Text, ActionIcon, Modal, Stack, TextInput, Select, Box } from "@mantine/core";
import { useDisclosure } from "@mantine/hooks";
import { notifications } from "@mantine/notifications";
import { IconEdit, IconTrash, IconUserPlus } from "@tabler/icons-react";
import axios from "axios";

// مدل دانش‌آموز مطابق API
interface Student {
    id: number;
    ssn: number;
    firstName: string;
    lastName: string;
}

export function StudentList() {
    const [students, setStudents] = useState<Student[]>([]);

    // مدیریت مدال‌های افزودن، ویرایش و حذف
    const [addModalOpened, { open: openAddModal, close: closeAddModal }] = useDisclosure(false);
    const [editModalOpened, { open: openEditModal, close: closeEditModal }] = useDisclosure(false);
    const [deleteModalOpened, { open: openDeleteModal, close: closeDeleteModal }] = useDisclosure(false);

    // state فرم افزودن دانش‌آموز جدید
    const [newStudent, setNewStudent] = useState<Omit<Student, "id">>({
        ssn: 0,
        firstName: "",
        lastName: "",
    });

    // state دانش‌آموز انتخاب‌شده جهت ویرایش یا حذف
    const [currentStudent, setCurrentStudent] = useState<Student | null>(null);

    // آدرس پایه API
    const baseUrl = "https://localhost:7075/api/Student";

    // دریافت لیست دانش‌آموزان از API
    const fetchStudents = async () => {
        try {
            const response = await axios.get(`${baseUrl}/Get`);
            setStudents(response.data);
        } catch (error) {
            console.error("Error fetching students:", error);
            notifications.show({
                title: "خطا در دریافت دانش‌آموزان",
                message: "مشکلی در دریافت اطلاعات از سرور به وجود آمد.",
                color: "red",
            });
        }
    };

    useEffect(() => {
        fetchStudents();
    }, []);

    // افزودن دانش‌آموز جدید از طریق API (ارسال داده به صورت raw)
    const handleAddStudent = async () => {
        try {
            await axios.post(`${baseUrl}/Create`, newStudent, {
                headers: { "Content-Type": "application/json" }
            });
            notifications.show({
                title: "دانش‌آموز افزوده شد",
                message: `${newStudent.firstName} ${newStudent.lastName} با موفقیت اضافه شد.`,
                color: "green",
            });
            fetchStudents();
            setNewStudent({ ssn: 0, firstName: "", lastName: "" });
            closeAddModal();
        } catch (error) {
            console.error("Error adding student:", error);
            notifications.show({
                title: "خطا در افزودن دانش‌آموز",
                message: "مشکلی در افزودن دانش‌آموز به وجود آمد.",
                color: "red",
            });
        }
    };

    // ویرایش دانش‌آموز از طریق API (ارسال داده به صورت raw)
    const handleEditStudent = async () => {
        if (!currentStudent) return;
        try {
            await axios.put(`${baseUrl}/Update`, currentStudent, {
                headers: { "Content-Type": "application/json" }
            });
            notifications.show({
                title: "دانش‌آموز به‌روز شد",
                message: `${currentStudent.firstName} ${currentStudent.lastName} با موفقیت به‌روز شد.`,
                color: "blue",
            });
            fetchStudents();
            closeEditModal();
        } catch (error) {
            console.error("Error editing student:", error);
            notifications.show({
                title: "خطا در به‌روز‌رسانی دانش‌آموز",
                message: "مشکلی در به‌روز‌رسانی دانش‌آموز به وجود آمد.",
                color: "red",
            });
        }
    };

    // حذف دانش‌آموز از طریق API (ارسال داده به صورت raw)
    const handleDeleteStudent = async () => {
        if (!currentStudent) return;
        try {
            await axios.delete(`${baseUrl}/Delete`, {
                data: { id: currentStudent.id },
                headers: { "Content-Type": "application/json" }
            });
            notifications.show({
                title: "دانش‌آموز حذف شد",
                message: `${currentStudent.firstName} ${currentStudent.lastName} با موفقیت حذف شد.`,
                color: "red",
            });
            fetchStudents();
            closeDeleteModal();
        } catch (error) {
            console.error("Error deleting student:", error);
            notifications.show({
                title: "خطا در حذف دانش‌آموز",
                message: "مشکلی در حذف دانش‌آموز به وجود آمد.",
                color: "red",
            });
        }
    };

    // باز کردن مدال ویرایش با اطلاعات دانش‌آموز انتخاب‌شده
    const openStudentEditModal = (student: Student) => {
        setCurrentStudent(student);
        openEditModal();
    };

    // باز کردن مدال حذف با اطلاعات دانش‌آموز انتخاب‌شده
    const openStudentDeleteModal = (student: Student) => {
        setCurrentStudent(student);
        openDeleteModal();
    };

    return (
        <>
            {/* عنوان و دکمه افزودن دانش‌آموز */}
            <Group justify="space-between" mb="md">
                <Text size="xl" fw={700}>
                    دانش‌آموزان
                </Text>
                <Button leftSection={<IconUserPlus size={16} />} onClick={openAddModal}>
                    افزودن دانش‌آموز جدید
                </Button>
            </Group>

            {/* جدول لیست دانش‌آموزان */}
            <Table striped highlightOnHover withTableBorder>
                <Table.Thead>
                    <Table.Tr>
                        <Table.Th>SSN</Table.Th>
                        <Table.Th>نام</Table.Th>
                        <Table.Th>نام خانوادگی</Table.Th>
                        <Table.Th>عملیات</Table.Th>
                    </Table.Tr>
                </Table.Thead>
                <Table.Tbody>
                    {students.map((student) => (
                        <Table.Tr key={student.id}>
                            <Table.Td>{student.ssn}</Table.Td>
                            <Table.Td>{student.firstName}</Table.Td>
                            <Table.Td>{student.lastName}</Table.Td>
                            <Table.Td>
                                <Group gap="xs">
                                    <ActionIcon variant="subtle" color="blue" onClick={() => openStudentEditModal(student)}>
                                        <IconEdit size={16} />
                                    </ActionIcon>
                                    <ActionIcon variant="subtle" color="red" onClick={() => openStudentDeleteModal(student)}>
                                        <IconTrash size={16} />
                                    </ActionIcon>
                                </Group>
                            </Table.Td>
                        </Table.Tr>
                    ))}
                </Table.Tbody>
            </Table>

            {/* مدال افزودن دانش‌آموز */}
            <Modal opened={addModalOpened} onClose={closeAddModal} title="افزودن دانش‌آموز جدید" centered>
                <Stack>
                    <TextInput
                        label="SSN"
                        placeholder="شماره شناسنامه"
                        type="number"
                        value={newStudent.ssn.toString()}
                        onChange={(e) => setNewStudent({ ...newStudent, ssn: Number(e.target.value) })}
                        required
                    />
                    <TextInput
                        label="نام"
                        placeholder="نام دانش‌آموز"
                        value={newStudent.firstName}
                        onChange={(e) => setNewStudent({ ...newStudent, firstName: e.target.value })}
                        required
                    />
                    <TextInput
                        label="نام خانوادگی"
                        placeholder="نام خانوادگی دانش‌آموز"
                        value={newStudent.lastName}
                        onChange={(e) => setNewStudent({ ...newStudent, lastName: e.target.value })}
                        required
                    />
                    <Group justify="flex-end" mt="md">
                        <Button variant="outline" onClick={closeAddModal}>
                            انصراف
                        </Button>
                        <Button onClick={handleAddStudent}>افزودن</Button>
                    </Group>
                </Stack>
            </Modal>

            {/* مدال ویرایش دانش‌آموز */}
            <Modal opened={editModalOpened} onClose={closeEditModal} title="ویرایش دانش‌آموز" centered>
                {currentStudent && (
                    <Stack>
                        <TextInput
                            label="SSN"
                            placeholder="شماره شناسنامه"
                            type="number"
                            value={currentStudent.ssn.toString()}
                            onChange={(e) => setCurrentStudent({ ...currentStudent, ssn: Number(e.target.value) })}
                            required
                        />
                        <TextInput
                            label="نام"
                            placeholder="نام دانش‌آموز"
                            value={currentStudent.firstName}
                            onChange={(e) => setCurrentStudent({ ...currentStudent, firstName: e.target.value })}
                            required
                        />
                        <TextInput
                            label="نام خانوادگی"
                            placeholder="نام خانوادگی دانش‌آموز"
                            value={currentStudent.lastName}
                            onChange={(e) => setCurrentStudent({ ...currentStudent, lastName: e.target.value })}
                            required
                        />
                        <Group justify="flex-end" mt="md">
                            <Button variant="outline" onClick={closeEditModal}>
                                انصراف
                            </Button>
                            <Button onClick={handleEditStudent}>ذخیره تغییرات</Button>
                        </Group>
                    </Stack>
                )}
            </Modal>

            {/* مدال تایید حذف دانش‌آموز */}
            <Modal opened={deleteModalOpened} onClose={closeDeleteModal} title="حذف دانش‌آموز" centered>
                <Box p="md">
                    <Text>آیا مطمئن هستید که می‌خواهید این دانش‌آموز را حذف کنید؟</Text>
                    <Text fw={700} mt="xs">
                        {currentStudent?.firstName} {currentStudent?.lastName}
                    </Text>
                    <Group justify="flex-end" mt="xl">
                        <Button variant="outline" onClick={closeDeleteModal}>
                            انصراف
                        </Button>
                        <Button color="red" onClick={handleDeleteStudent}>
                            حذف
                        </Button>
                    </Group>
                </Box>
            </Modal>
        </>
    );
}
