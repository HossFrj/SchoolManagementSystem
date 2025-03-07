import { useState } from "react";
import { createRoot } from "react-dom/client";
import { AppShell, MantineProvider } from "@mantine/core";
import Navbar from "../../component/common/NabBar";
import StudentList from "../../component/feature/Home/StudentList";
import LogList from "../../component/feature/Home/LogList";
import { Notifications } from "@mantine/notifications";
import "@mantine/core/styles.css"
import "@mantine/notifications/styles.css"

const App = () => {
    const [activeView, setActiveView] = useState<string>("لیست دانش آموزان");

    return (
        <MantineProvider>
            <Notifications position="top-right" />
        <AppShell
            className="p-4 container mx-auto"
            dir="rtl"
            navbar={{
                width: 300,
                breakpoint: "sm",
                collapsed: { mobile: false },
            }}
        >
            <AppShell.Navbar>
                <Navbar
                    active={activeView}
                    onSelect={(label) => setActiveView(label)}
                />
            </AppShell.Navbar>

            <AppShell.Main>
                {activeView === "لیست دانش آموزان" ? (
                    <StudentList />
                ) : (
                    <LogList />
                )}
            </AppShell.Main>
            </AppShell>
        </MantineProvider>
    );
};

createRoot(document.getElementById("root")!).render(<App />);
