import React from "react";
import { useFormik } from "formik";
import * as Yup from "yup";
import { Button, TextField, Box } from "@mui/material";
import { useContext } from "react";
import EmployeeContext from "../Context/EmployeeContext";

const EmployeeForm = () => {
  const { addEmployee } = useContext(EmployeeContext);

  const formik = useFormik({
    initialValues: {
      name: "",
      email: "",
      designation: "",
    },
    validationSchema: Yup.object({
      name: Yup.string().required("Name is required"),
      email: Yup.string().email("Invalid email format").required("Email is required"),
      designation: Yup.string().required("Designation is required"),
    }),
    onSubmit: (values, { resetForm }) => {
      addEmployee(values);
      alert("Employee Added");
      resetForm();
    },
  });

  return (
    <Box sx={{ maxWidth: 400, margin: "auto", padding: 2 }}>
      <form onSubmit={formik.handleSubmit}>
        <TextField
          fullWidth
          id="name"
          name="name"
          label="Name"
          value={formik.values.name}
          onChange={formik.handleChange}
          error={formik.touched.name && Boolean(formik.errors.name)}
          helperText={formik.touched.name && formik.errors.name}
        />
        <TextField
          fullWidth
          id="email"
          name="email"
          label="Email"
          value={formik.values.email}
          onChange={formik.handleChange}
          error={formik.touched.email && Boolean(formik.errors.email)}
          helperText={formik.touched.email && formik.errors.email}
          sx={{ mt: 2 }}
        />
        <TextField
          fullWidth
          id="designation"
          name="designation"
          label="Designation"
          value={formik.values.designation}
          onChange={formik.handleChange}
          error={formik.touched.designation && Boolean(formik.errors.designation)}
          helperText={formik.touched.designation && formik.errors.designation}
          sx={{ mt: 2 }}
        />
        <Button color="primary" variant="contained" fullWidth type="submit" sx={{ mt: 2 }}>
          Add Employee
        </Button>
      </form>
    </Box>
  );
};

export default EmployeeForm;
