import DataGrid from "@/components/Data/DataGrid";
import { IEmployee } from "@/interfaces/employee";
import { loadDictionary } from "@/utils/general";
import { use } from "react";
import { Col, Container, Row } from "react-bootstrap";

async function getData() {
    const res = await fetch(
        `${process.env.NEXT_PUBLIC_API_URL}/employees`
    )

    return await res.json();
}

export default function Page() {
    const employees: IEmployee[] = use(getData());
    return (
        <Container>
            <Row>
                <Col xs={12}>
                    <h3>Dolgozók</h3>
                </Col>
            </Row>
            <DataGrid
                records={employees}
                columns={[
                    "id",
                    "first_name",
                    "last_name",
                    "institutions.*.institution.name",
                    "institutions.*.institution.city"
                ]}
                dictionary={use(loadDictionary("dataTables"))}
                namespace="employees"
            />
        </Container>
    )
}