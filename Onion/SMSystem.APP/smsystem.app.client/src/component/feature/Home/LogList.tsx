import {JSX, useEffect, useState} from "react";
import { Container, Table} from "@mantine/core";
import {notifications} from "@mantine/notifications";
import axios from "axios";

interface Student {
    id: number;
    ssn: number;
    firstName: string;
    lastName: string;
}

const LogList = () : JSX.Element=> {
    const [students, setStudents] = useState<Student[]>([]);
    const baseUrl = "https://localhost:7075/api/Student";

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


  
    return (
        <Container fluid>
            <Table striped highlightOnHover withTableBorder mt={50}>
                <Table.Thead>
                    <Table.Tr>
                        <Table.Th>SSN</Table.Th>
                        <Table.Th>نام</Table.Th>
                        <Table.Th>نام خانوادگی</Table.Th>
                    </Table.Tr>
                </Table.Thead>
                <Table.Tbody>
                    {students.map((student) => (
                        <Table.Tr key={student.id}>
                            <Table.Td>{student.id}</Table.Td>
                            <Table.Td>{student.ssn}</Table.Td>
                            <Table.Td>{student.firstName}</Table.Td>
                            <Table.Td>{student.lastName}</Table.Td>
                        </Table.Tr>
                    ))}
                </Table.Tbody>
            </Table>

           

        </Container>
    );
}
export default LogList;