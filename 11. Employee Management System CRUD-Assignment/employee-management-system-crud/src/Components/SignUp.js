import React, { useContext } from "react";
import { TextField, Button, Paper, Typography } from "@mui/material";
import { Formik, Form, Field } from "formik";
import * as Yup from "yup";
import EmployeeContext from "../Context/EmployeeContext";

const SignUp = () => {
  const initialValues = {
    username: "",
    email: "",
    password: "",
  };

  const {users, addUser} = useContext(EmployeeContext);

  const validationSchema = Yup.object({
    username: Yup.string().required("Username is required"),
    email: Yup.string().email("Invalid email").required("Email is required"),
    password: Yup.string()
      .matches(
        /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/,
        "Password must contain at least 8 characters, one uppercase, one lowercase, one number, and one special character"
      )
      .required("Password is required"),
  });

  const handleSubmit = async (values, { resetForm }) => {
    try {
      const existingUser = await users.find(
        (u) => u.username === values.username || u.email === values.email
      );
  
      if (existingUser)
      {
        if (existingUser.username === values.username) 
        {
          alert("Username already exists!");
        }
        else if (existingUser.email === values.email) {
          alert("Email ID already exists!");
        }
      } 
      else
      {
        addUser(values);
        alert("SignUp Successful");
        resetForm();
      }
    }
    catch (error)
    {
      console.error("Error during sign-up:", error);
      alert("An error occurred while connecting to the server.");
    }
  };
  

  return (
    <Paper elevation={3} sx={{ p: 4, maxWidth: 400, margin: "50px auto" }}>
      <Typography variant="h4" textAlign="center" gutterBottom>
        Sign Up
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
              name="username"
              label="Username"
              fullWidth
              error={touched.username && Boolean(errors.username)}
              helperText={touched.username && errors.username}
              margin="normal"
            />
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
              Sign Up
            </Button>
          </Form>
        )}
      </Formik>
    </Paper>
  );
};

export default SignUp;
