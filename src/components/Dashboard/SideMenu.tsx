"use client";

import { 
    CDBSidebar,
    CDBSidebarHeader,
    CDBSidebarContent,
    CDBSidebarMenu,
    CDBSidebarMenuItem,
    CDBSidebarFooter
} from "cdbreact";
import { useCookies } from "next-client-cookies";
import Link from "next/link";
import { FaBars } from "react-icons/fa";
import { LuLogOut } from "react-icons/lu";

export default function SideMenu() {
    const t = useCookies();

    return (
        <div 
            className="d-flex" 
            style={{height: '100vh', overflow: 'scroll initial'}}
        >
            <CDBSidebar textColor="#fff" backgroundColor="#333">
                <CDBSidebarHeader prefix={<FaBars />}>
                    Szabadság kezelő
                </CDBSidebarHeader>

                <CDBSidebarContent>
                    <CDBSidebarMenu>
                        <Link href="/">
                            <CDBSidebarMenuItem icon="tachometer-alt">
                                Dashboard
                            </CDBSidebarMenuItem>
                        </Link>
                    </CDBSidebarMenu>
                    <CDBSidebarMenu>
                        <Link href="/employees">
                            <CDBSidebarMenuItem icon="user">
                                Dolgozók
                            </CDBSidebarMenuItem>
                        </Link>
                    </CDBSidebarMenu>
                    <CDBSidebarMenu>
                        <Link href="/groups">
                            <CDBSidebarMenuItem icon="users">
                                Csoportok
                            </CDBSidebarMenuItem>
                        </Link>
                    </CDBSidebarMenu>
                    <CDBSidebarMenu>
                        <Link href="/institutions">
                            <CDBSidebarMenuItem icon="university">
                                Intézmények
                            </CDBSidebarMenuItem>
                        </Link>
                    </CDBSidebarMenu>
                    <CDBSidebarMenu>
                        <Link href="/calendar">
                            <CDBSidebarMenuItem icon="calendar" iconType="solid">
                                Naptár
                            </CDBSidebarMenuItem>
                        </Link>
                    </CDBSidebarMenu>
                    <CDBSidebarMenu>
                        <Link href="/holidays">
                            <CDBSidebarMenuItem icon="umbrella-beach" iconType="solid">
                                Munkaszüneti napok
                            </CDBSidebarMenuItem>
                        </Link>
                    </CDBSidebarMenu>
                </CDBSidebarContent>
                <CDBSidebarFooter>
                    <div 
                        className="d-flex align-items-center justify-content-center p-3"
                        onClick={() => {
                            t.remove("user");
                            location.href="/login"
                        }}
                        style={{"cursor": "pointer"}}
                    >
                        <LuLogOut className="me-2"/>
                        <span>Kijelentkezés</span>
                    </div>
                </CDBSidebarFooter>
            </CDBSidebar>
        </div>
    )
}