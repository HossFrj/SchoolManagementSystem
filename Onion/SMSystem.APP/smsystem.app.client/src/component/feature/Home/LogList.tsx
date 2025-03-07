import  { JSX, useEffect, useState } from "react";
import { Container, Table } from "@mantine/core";
import { notifications } from "@mantine/notifications";
import { logApi, Log } from "../../../api/Home/Log";

const LogList = (): JSX.Element => {
    const [logs, setLogs] = useState<Log[]>([]);

    const fetchLogs = async () => {
        try {
            const data = await logApi.getLogs();
            setLogs(data);
        } catch (error) {
            console.error("Error fetching logs:", error);
            notifications.show({
                title: "خطا در دریافت لاگ ها",
                message: "مشکلی در دریافت اطلاعات از سرور به وجود آمد.",
                color: "red",
            });
        }
    };

    useEffect(() => {
        fetchLogs();
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
};

export default LogList;