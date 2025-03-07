import React, {JSX, useEffect, useState} from "react";
import { Container, Table} from "@mantine/core";
import {notifications} from "@mantine/notifications";
import axios from "axios";

interface Student {
    outBoxEventItemId: number;
    accuredOn:  React.ReactNode;
    aggregateName: string;
    eventName: string;
}

const LogList = () : JSX.Element=> {
    const [logs, setLogs] = useState<Student[]>([]);
    const baseUrl = "https://localhost:7075/api/OutBoxEventItem";

    const fetchStudents = async () => {
        try {
            const response = await axios.get(`${baseUrl}/Get`);
            setLogs(response.data);
        } catch (error) {
            console.error("Error fetching students:", error);
            notifications.show({
                title: "خطا در دریافت لاگ ها",
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
                        <Table.Th>ID Log</Table.Th>
                        <Table.Th>زمان</Table.Th>
                        <Table.Th>جدول</Table.Th>
                        <Table.Th>نوع عملیات</Table.Th>
                    </Table.Tr>
                </Table.Thead>
                <Table.Tbody>
                    {logs.map((log) => (
                        <Table.Tr key={log.outBoxEventItemId}>
                            <Table.Td>{log.outBoxEventItemId}</Table.Td>
                            <Table.Td>{log.accuredOn}</Table.Td>
                            <Table.Td>{log.aggregateName}</Table.Td>
                            <Table.Td>{log.eventName}</Table.Td>
                        </Table.Tr>
                    ))}
                </Table.Tbody>
            </Table>

           

        </Container>
    );
}
export default LogList;