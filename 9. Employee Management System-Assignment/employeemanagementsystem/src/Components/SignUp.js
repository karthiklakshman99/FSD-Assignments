import React, { useState } from "react";
import { TextField, Button, Box, Typography, Grid } from "@mui/material";

const SignUp = () => {
  const [formData, setFormData] = useState({
    username: "",
    email: "",
    password: "",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log("Sign Up Data:", formData);
  };

  return (
    <Box sx={{ flexGrow: 1, p: 3 }}>
      <Grid container justifyContent="center" spacing={3}>
        <Grid item xs={12} md={6}>
          <Typography variant="h4" gutterBottom>
            Sign Up
          </Typography>
          <form onSubmit={handleSubmit}>
            <TextField
              name="username"
              label="Username"
              fullWidth
              margin="normal"
              value={formData.username}
              onChange={handleChange}
            />
            <TextField
              name="email"
              label="Email"
              type="email"
              fullWidth
              margin="normal"
              value={formData.email}
              onChange={handleChange}
            />
            <TextField
              name="password"
              label="Password"
              type="password"
              fullWidth
              margin="normal"
              value={formData.password}
              onChange={handleChange}
            />
            <Button variant="contained" color="primary" type="submit" fullWidth>
              Sign Up
            </Button>
          </form>
        </Grid>
      </Grid>
    </Box>
  );
};

export default SignUp;
