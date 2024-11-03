import type { Metadata } from 'next'
import { Inter } from 'next/font/google'
import 'bootstrap/dist/css/bootstrap.min.css'
import { Col, Container, Row } from 'react-bootstrap'
import { cookies } from 'next/headers'
import SideMenu from '@/components/Dashboard/SideMenu'
import { redirect } from 'next/navigation'

const inter = Inter({ subsets: ['latin'] })

export const metadata: Metadata = {
  title: {
    default: "VMSZC Szabadság kezelő",
    template: "%s - VMSZ Szabadság kezelő"
  }
}

export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  const user = cookies().get("user");

  return (
    <html lang="en">
      <body className={inter.className}>
        {!user ? (
          <Container fluid className='p-0 overflow-hidden'>
            {children}
          </Container>
        ) : (
          <Container fluid className='p-0 overflow-hidden'>
            <div className={"d-flex"}>
              <SideMenu />
              <div 
                className={"d-flex px-5 pt-3"}
                style={{"minWidth": "79vw"}}
              >
                {children}
              </div>
            </div>
          </Container>
        )}
      </body>
    </html>
  )
}
