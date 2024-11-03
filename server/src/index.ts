import express from "express"
import cors from "cors"
import 'dotenv/config'
import institutions from './routes/institutions'
import employee from './routes/employees'
import roles from './routes/roles';
import dayOffs from './routes/dayOffs';
import groups from './routes/groups';

const app = express()

app.use(express.json())
app.use(express.urlencoded({ extended: true }))
app.use(cors())

app.use("/institutions", institutions)
app.use("/employees", employee)
app.use("/roles", roles);
app.use("/day-offs", dayOffs);
app.use("/groups", groups);

app.listen(process.env.PORT, () => {
    console.log(`Server running on ${process.env.PORT} port`)
})