"use client"
import Link from "next/link";
import { ReactElement } from "react";
import { Button, ButtonGroup, Col, Row, Table } from "react-bootstrap";
import { FaTrash } from "react-icons/fa";
import { FaPenToSquare } from "react-icons/fa6";
import "@/styles/dataGrid.css";

type ActionButton = {
    color: string
    icon: ReactElement
    type: 'update' | 'delete'
}

export default function DataGrid({
    records,
    columns,
    dictionary,
    actionButtons = [
        {
            color: "success",
            icon: (<FaPenToSquare />),
            type: "update"
        },
        {
            color: "danger",
            icon: (<FaTrash />),
            type: "delete"
        }
    ],
    namespace
} : {
    records: Record<string, any>[]
    columns: string[],
    dictionary: Record<string, any>,
    actionButtons?: ActionButton[],
    namespace: string
}) {
    
    function getTitle(key: string) {
        if (key.includes(".")) {
            const layers = key.split(".");
            let currentValue = dictionary;
            let found = false;
            layers.forEach((layerKey) => {
                if (!found && currentValue[layerKey]) {
                    currentValue = currentValue[layerKey];
                } else {
                    found = true;
                }
            })
            if (found) {
                return key;
            }
            return currentValue;
        } else {
            return dictionary[key]
        }
    }

    function getRecordValue(record: Record<string, any>, key: string) {
        if (key.includes(".")) {
            const layers = key.split(".");
            let currentValue = record;
            layers.forEach((layerKey, layerIndex) => {
                if (currentValue[layerKey] && layerKey !== "*") {
                    currentValue = currentValue[layerKey];
                } else {
                    if (layerKey === "*") {
                        const m = currentValue.map((subValue: Record<any, string>) => {
                            const nextLayers = layers.slice(layerIndex+1)
                            let currentSubValue = subValue;

                            nextLayers.forEach(nextLayer => {
                                currentSubValue = currentSubValue[nextLayer]
                            })
                            return currentSubValue;
                        })

                        
                        currentValue = m.join(", ")
                    }
                    return "";
                }
            })
            return currentValue;
        } else {
            return record[key];
        }
    }

    return (
        <Row>
            <Col xs={12} className="text-end mb-3">
                <Button variant="success">{getTitle("create")}</Button>
            </Col>
            <Col xs={12}>
                <Table striped bordered hover>
                    <thead>
                        <tr>
                            <th></th>
                            {columns && columns.map(col => (
                                <th>
                                    {getTitle(col)}
                                </th>
                            ))}
                        </tr>
                    </thead>
                    <tbody>
                        {records && records.map(record => (
                            <tr>
                                <td className="text-center">
                                    <ButtonGroup>
                                        {actionButtons && actionButtons.map(button => (
                                            <Link 
                                                href={`/${namespace}/${button.type}/${record.id}`}
                                            >
                                                <Button 
                                                    variant={button.color} 
                                                    title={getTitle(button.type)}
                                                >
                                                    {button.icon}
                                                </Button>
                                            </Link>
                                        ))}
                                    </ButtonGroup>
                                </td>
                                {(columns && records) && columns.map(col => (
                                    <td>
                                        {getRecordValue(record, col)}
                                    </td>
                                ))}
                            </tr>
                        ))}
                    </tbody>
                </Table>
            </Col>
        </Row>
    )
}