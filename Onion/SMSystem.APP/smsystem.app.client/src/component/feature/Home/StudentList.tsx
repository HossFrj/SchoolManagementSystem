import { JSX, useEffect, useState } from "react";
import { ActionIcon, Box, Button, Container, Group, Modal, Stack, Table, Text, TextInput } from "@mantine/core";
import { useDisclosure } from "@mantine/hooks";
import { notifications } from "@mantine/notifications";
import { IconEdit, IconTrash, IconUserPlus } from "@tabler/icons-react";
import { studentApi, Student } from "../../../api/Home/Student";

const StudentList = (): JSX.Element => {
    const [students, setStudents] = useState<Student[]>([]);
    const [addModalOpened, { open: openAddModal, close: closeAddModal }] = useDisclosure(false);
    const [editModalOpened, { open: openEditModal, close: closeEditModal }] = useDisclosure(false);
    const [deleteModalOpened, { open: openDeleteModal, close: closeDeleteModal }] = useDisclosure(false);

    const [newStudent, setNewStudent] = useState<Omit<Student, "id">>({
        ssn: "",
        firstName: "",
        lastName: "",
    });

    const [currentStudent, setCurrentStudent] = useState<Student | null>(null);

    const fetchStudents = async () => {
        try {
            const data = await studentApi.getStudents();
            setStudents(data);
        } catch (error) {
            console.error("Error:", error);
            notifications.show({
                title: "خطا",
                message: "مشکلی در دریافت اطلاعات از سرور به وجود آمد",
                color: "red",
            });
        }
    };

    useEffect(() => {
        fetchStudents();
    }, []);

    const handleAddStudent = async () => {
        try {
            await studentApi.createStudent(newStudent);
            notifications.show({
                title: "دانش‌آموز افزوده شد",
                message: `${newStudent.firstName} ${newStudent.lastName} با موفقیت اضافه شد`,
                color: "green",
            });
            fetchStudents();
            setNewStudent({ ssn: "", firstName: "", lastName: "" });
            closeAddModal();
        } catch (error) {
            console.error("Error:", error);
            notifications.show({
                title: "خطا",
                message: "مشکلی در افزودن دانش‌آموز به وجود آمد",
                color: "red",
            });
        }
    };

    const handleEditStudent = async () => {
        if (!currentStudent) return;
        try {
            await studentApi.updateStudent(currentStudent);
            notifications.show({
                title: "دانش‌آموز به‌روز شد",
                message: `${currentStudent.firstName} ${currentStudent.lastName} با موفقیت به‌روز شد`,
                color: "blue",
            });
            fetchStudents();
            closeEditModal();
        } catch (error) {
            console.error("Error:", error);
            notifications.show({
                title: "خطا",
                message: "مشکلی در به‌روزرسانی دانش‌آموز به وجود آمد",
                color: "red",
            });
        }
    };

    const handleDeleteStudent = async () => {
        if (!currentStudent) return;
        try {
            await studentApi.deleteStudent(currentStudent.id);
            notifications.show({
                title: "دانش‌آموز حذف شد",
                message: `${currentStudent.firstName} ${currentStudent.lastName} با موفقیت حذف شد`,
                color: "red",
            });
            fetchStudents();
            closeDeleteModal();
        } catch (error) {
            console.error("Error:", error);
            notifications.show({
                title: "خطا",
                message: "مشکلی در حذف دانش‌آموز به وجود آمد",
                color: "red",
            });
        }
    };


    const openStudentEditModal = (student: Student) => {
        setCurrentStudent(student);
        openEditModal();
    };

    const openStudentDeleteModal = (student: Student) => {
        setCurrentStudent(student);
        openDeleteModal();
     };

     const handleOpenAddModal = () => {
         setNewStudent({ ssn: "", firstName: "", lastName: "" });
         openAddModal();
     };
    return (
        <Container fluid mt={50}>
            <Group justify="space-between" mb="md" >
                <Button leftSection={<IconUserPlus size={16} />} onClick={handleOpenAddModal}>
                    افزودن دانش‌آموز جدید
                </Button>
            </Group>

            <Table striped highlightOnHover withTableBorder>
                <Table.Thead>
                    <Table.Tr>
                        <Table.Th>Id Student</Table.Th>
                        <Table.Th>شماره ملی</Table.Th>
                        <Table.Th>نام</Table.Th>
                        <Table.Th>نام خانوادگی</Table.Th>
                        <Table.Th>عملیات</Table.Th>
                    </Table.Tr>
                </Table.Thead>
                <Table.Tbody>
                    {students.map((student) => (
                        <Table.Tr key={student.id}>
                            <Table.Td>{student.id}</Table.Td>
                            <Table.Td>{student.ssn}</Table.Td>
                            <Table.Td>{student.firstName}</Table.Td>
                            <Table.Td>{student.lastName}</Table.Td>
                            <Table.Td>
                                <Group gap="xs">
                                    <ActionIcon variant="subtle" color="blue"
                                                onClick={() => openStudentEditModal(student)}>
                                        <IconEdit size={16}/>
                                    </ActionIcon>
                                    <ActionIcon variant="subtle" color="red"
                                                onClick={() => openStudentDeleteModal(student)}>
                                        <IconTrash size={16}/>
                                    </ActionIcon>
                                </Group>
                            </Table.Td>
                        </Table.Tr>
                    ))}
                </Table.Tbody>
            </Table>

            <Modal dir={'rtl'} opened={addModalOpened} onClose={closeAddModal} title="افزودن دانش‌آموز جدید" centered>
                <Stack>
                    <TextInput
                        label="شماره ملی"
                        placeholder="شماره شناسنامه"
                        type="number"
                        value={newStudent.ssn.toString()}
                        onChange={(e) => setNewStudent({...newStudent, ssn: (e.target.value)})}
                        required
                    />
                    <TextInput
                        label="نام"
                        placeholder="نام دانش‌آموز"
                        value={newStudent.firstName}
                        onChange={(e) => setNewStudent({...newStudent, firstName: e.target.value})}
                        required
                    />
                    <TextInput
                        label="نام خانوادگی"
                        placeholder="نام خانوادگی دانش‌آموز"
                        value={newStudent.lastName}
                        onChange={(e) => setNewStudent({...newStudent, lastName: e.target.value})}
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

            <Modal opened={editModalOpened} dir={'rtl'} onClose={closeEditModal} title="ویرایش دانش‌آموز" centered>
                {currentStudent && (
                    <Stack>
                        <TextInput
                            label="شماره ملی"
                            placeholder="شماره شناسنامه"
                            type="number"
                            value={currentStudent.ssn.toString()}
                            onChange={(e) => setCurrentStudent({ ...currentStudent, ssn: (e.target.value) })}
                            required
                        />
                        <TextInput
                            label="نام"
                            placeholder="نام دانش‌آموز"
                            value={currentStudent.firstName}
                            onChange={(e) => setCurrentStudent({...currentStudent, firstName: e.target.value})}
                            required
                        />
                        <TextInput
                            label="نام خانوادگی"
                            placeholder="نام خانوادگی دانش‌آموز"
                            value={currentStudent.lastName}
                            onChange={(e) => setCurrentStudent({...currentStudent, lastName: e.target.value})}
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

            <Modal dir={'rtl'} opened={deleteModalOpened} onClose={closeDeleteModal} title="حذف دانش‌آموز" centered>
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
        </Container>
    );
}
export default StudentList;