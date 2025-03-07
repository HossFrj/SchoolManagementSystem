
import { StudentList } from "./App.tsx"
import { MantineProvider } from "@mantine/core"
import { Notifications } from "@mantine/notifications"
import "@mantine/core/styles.css"
import "@mantine/notifications/styles.css"
import { createRoot } from "react-dom/client"

createRoot(document.getElementById('root')!).render(
    <MantineProvider>
        <Notifications position="top-right" />
        <main className="p-4 container mx-auto">
            <h1 className="mb-6 text-2xl font-bold">User Management</h1>
            <StudentList />
        </main>
    </MantineProvider>
)

