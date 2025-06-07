import React, { useContext } from "react";
import { TextField, Button, Paper, Typography } from "@mui/material";
import { Formik, Form, Field } from "formik";
import * as Yup from "yup";
import EmployeeContext from "../Context/EmployeeContext";
import { useNavigate } from "react-router-dom";

const Login = () => {
  const { users } = useContext(EmployeeContext);
  const navigate = useNavigate();

  const initialValues = {
    email: "",
    password: "",
  };

  const validationSchema = Yup.object({
    email: Yup.string().email("Invalid email").required("Email is required"),
    password: Yup.string().required("Password is required"),
  });

  const handleSubmit = (values, { resetForm }) => {
    if (!users || users.length === 0)
    {
      alert("Users data is not loaded. Please try again later.");
      return;
    }

    const existingUser = users.find(
      (user) => user.email === values.email && user.password === values.password
    );

    if (existingUser)
    {
      navigate("/Dashboard");
      resetForm();
    }
    else
    {
      alert("Invalid Login Credentials!");
      resetForm();
    }
  };

  return (
    <Paper elevation={3} sx={{ p: 4, maxWidth: 400, margin: "50px auto" }}>
      <Typography variant="h4" textAlign="center" gutterBottom>
        Login
      </Typography>
      <Formik
        initialValues={initialValues}
        validationSchema={validationSchema}
        onSubmit={handleSubmit}
      >
        {({ errors, touched }) => (
          <Form>
            <Field
              as={TextField}
              name="email"
              label="Email"
              fullWidth
              error={touched.email && Boolean(errors.email)}
              helperText={touched.email && errors.email}
              margin="normal"
            />
            <Field
              as={TextField}
              name="password"
              label="Password"
              type="password"
              fullWidth
              error={touched.password && Boolean(errors.password)}
              helperText={touched.password && errors.password}
              margin="normal"
            />
            <Button type="submit" variant="contained" color="primary" fullWidth>
              Login
            </Button>
          </Form>
        )}
      </Formik>
    </Paper>
  );
};

export default Login;
