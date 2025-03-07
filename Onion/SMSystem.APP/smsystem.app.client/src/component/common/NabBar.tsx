import {IconClipboardList, IconSchool,} from '@tabler/icons-react';
import {Group, Title} from '@mantine/core';
import classes from './Navbar.module.css';

interface NavbarProps {
    active: string;
    onSelect: (label: string) => void;
}

const data = [
    { label: 'لیست دانش آموزان', icon: IconSchool},
    { label: 'لاگ ها', icon: IconClipboardList},
];

 const  Navbar = ({active, onSelect}: NavbarProps) => {
    const links = data.map((item) => (
        <a
            className={classes.link}
            data-active={item.label === active || undefined}
            key={item.label}
            onClick={(event) => {
                event.preventDefault();
                onSelect(item.label);
            }}
        >
            <item.icon className={classes.linkIcon} stroke={1.5}/>
            <span>{item.label}</span>
        </a>
    ));

    return (
        <nav className={classes.navbar}>
            <Title order={5} c={'white'}>سامانه مدیریت مدرسه </Title>
            <div className={classes.navbarMain}>
                <Group className={classes.header} justify="space-between">
                </Group>
                {links}
            </div>
        </nav>
    );
}
export default Navbar;