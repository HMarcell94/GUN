import LoginForm from '@/components/Login/LoginForm'
import { cookies } from 'next/headers';
import { redirect } from 'next/navigation';
import { Col, Row } from 'react-bootstrap'

export default function Home() {
  const user = cookies().get("user");

  if (user) {
      redirect("/")
  }
  
  return (
    <Row 
      className='mt-5 pt-5 d-flex justify-content-center align-items-center'
    >
      <Col xs={10} md={5} lg={10} className='pb-4 pb-md-2'>
        <h2>Bejelenetkezés</h2>
      </Col>
      <Col xs={10} md={5} lg={10}>
        <LoginForm />
      </Col>
    </Row>
  )
}
