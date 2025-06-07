import React from "react";
import { Box, Button, Stack, TextField, Typography } from "@mui/material";
import { useFormik } from "formik";
import * as Yup from "yup";

const EmployeeForm = () => {
  const validationSchema = Yup.object({
    name: Yup.string().required("Name is required"),
    email: Yup.string().email("Invalid email format").required("Email is required"),
    designation: Yup.string().required("Designation is required"),
  });

  const formik = useFormik({
    initialValues: {
      name: "",
      email: "",
      designation: "",
    },
    validationSchema,
    onSubmit: (values) => {
      console.log("Employee Details:", values);
      alert("Form submitted successfully!");
    },
  });

  return (
    <Box sx={{ padding: 4, maxWidth: 500, margin: "auto", boxShadow: 3, borderRadius: 2 }}>
      <Typography variant="h4" gutterBottom align="center">
        Employee Form
      </Typography>
      <form onSubmit={formik.handleSubmit}>
        <Stack spacing={3}>
          <TextField
            fullWidth
            label="Name"
            name="name"
            value={formik.values.name}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            error={formik.touched.name && Boolean(formik.errors.name)}
            helperText={formik.touched.name && formik.errors.name}
          />
          <TextField
            fullWidth
            label="Email"
            name="email"
            type="email"
            value={formik.values.email}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            error={formik.touched.email && Boolean(formik.errors.email)}
            helperText={formik.touched.email && formik.errors.email}
          />
          <TextField
            fullWidth
            label="Designation"
            name="designation"
            value={formik.values.designation}
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            error={formik.touched.designation && Boolean(formik.errors.designation)}
            helperText={formik.touched.designation && formik.errors.designation}
          />
          <Button type="submit" variant="contained" color="primary" fullWidth>
            Submit
          </Button>
        </Stack>
      </form>
    </Box>
  );
};

export default EmployeeForm;
