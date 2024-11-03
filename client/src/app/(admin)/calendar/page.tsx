import {  Container } from "react-bootstrap";
import { use } from "react";
import "@/styles/calendar.css"
import Calendar from "@/components/Calendar/Calendar";

async function getData() {
    const res = await fetch(
        `${process.env.NEXT_PUBLIC_API_URL}/employees`
    )

    return await res.json();
}

export default function Page() {
    const employees = use(getData());
    
    return (
        <Container fluid>
            <Calendar employees={employees}/>
        </Container>
    )
}