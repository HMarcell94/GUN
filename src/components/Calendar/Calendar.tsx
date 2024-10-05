"use client";

import { IEmployee } from "@/interfaces/employee";
import moment from "moment";
import { Badge, Button, Col, OverlayTrigger, Row, Table, Tooltip } from "react-bootstrap";
import "moment/locale/hu"
import { useState, useEffect } from "react";
import { FaChevronLeft, FaChevronRight } from "react-icons/fa";

export default function Calendar({
    employees
} : {
    employees: IEmployee[]
}) {
    //const month = moment().month();
    //const date = moment().locale("hu").set("month", month)
    //const days = date.daysInMonth()
    const [year, setYear] = useState(moment().year());
    const [month, setMonth] = useState(moment().month());
    const [date, setDate] = useState(moment().locale("hu").set(
        "month",
        month).set("year", year)
    );
    const [days, setDays] = useState(date.daysInMonth());

    function getUserState(employee: IEmployee, day: number) {
        let status = (<></>);
        employee.dayOffs.forEach(dayOff => {
            const from = moment(dayOff.from).startOf("day")
            const to = moment(dayOff.to).endOf("day")
            const checkDate = moment().set({
                'year': year,
                'month': month,
                'date': day
            })
            
            if (checkDate.isBetween(from, to)) {
                let color = 'info';
                let text = 'SZ';
                if (dayOff.resolved_by) {
                    color = 'success'
                }
                if (dayOff.is_plan) {
                    color = 'warning'
                    text = 'T';
                }
                const tooltip = (
                    <Tooltip>
                        Napok száma: {dayOff.days}<br />
                        Indoklás: {dayOff.reason}<br />
                        {dayOff.resolved_by && (
                            <>
                                Elfogadta: {dayOff.resolved.first_name}
                                &nbsp;{dayOff.resolved.last_name}
                            </>
                        )}
                    </Tooltip>
                )
                status = (
                    <OverlayTrigger overlay={tooltip}>
                        <Badge 
                            bg={color}
                        >
                            {text}
                        </Badge>
                    </OverlayTrigger>
                )
            }
        })
        return status;
    }

    function isWeekend(day: number) {
        const weekDay = moment().set({
            'year': year,
            'month': month,
            'date': day
        }).weekday();

        return weekDay === 5 || weekDay === 6;
    }

    useEffect(() => {
        setDate(moment().locale("hu")
        .set("month",month)
        .set("year", year))
    }, [month])

    useEffect(() => {
        setDays(date.daysInMonth());
    }, [date])

    return (
        <>
            <Row className={"text-center pb-3"}>
                <Col>
                    <Button variant={"primary"} onClick={() => {
                        let current = month
                        if (current === 0) {
                            current = 11
                            setYear(year - 1)
                        } else {
                            current--;
                        }
                        setMonth(current)
                    }}>
                        <FaChevronLeft />
                    </Button>
                </Col>
                <Col>
                    {date.format("Y. MMMM")}
                </Col>
                <Col>
                    <Button variant={"primary"} onClick={() => {
                        let current = month;
                        if (current === 11) {
                            current = 0;
                            setYear(year + 1)
                        } else {
                            current++;
                        }
                        setMonth(current)
                    }}>
                        <FaChevronRight />
                    </Button>
                </Col>
            </Row>
            <Table striped hover bordered responsive>
                <thead>
                    <tr>
                        <th>Személy</th>
                        {Array.from({ length: days}, (v,k) => (
                            <th className={isWeekend(k+1)?"weekend":""}>
                                {k+1}
                            </th>
                        ))}
                    </tr>
                </thead>
                <tbody>
                    {employees && employees.map((employee: IEmployee) => (
                        <tr key={employee.id}>
                            <td>
                                {employee.first_name} {employee.last_name}
                            </td>
                            {Array.from({ length: days}, (v,k) => (
                                <td className={isWeekend(k+1)?"weekend":""}>
                                    {getUserState(employee, k+1)}
                                </td>
                            ))}
                        </tr>
                    ))}
                </tbody>
            </Table>
        </>
    )
}