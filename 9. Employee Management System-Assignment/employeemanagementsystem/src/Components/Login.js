import React, { useState } from "react";
import { TextField, Button, Typography, Box, Stack } from "@mui/material";

const Login = () => {
  const [credentials, setCredentials] = useState({
    username: "",
    password: "",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setCredentials({ ...credentials, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log("Login Credentials:", credentials);
  };

  return (
    <Box sx={{ padding: 4, maxWidth: 400, margin: "auto" }}>
      <Typography variant="h4" gutterBottom align="center">
        Login
      </Typography>
      <form onSubmit={handleSubmit}>
        <Stack spacing={3}>
          <TextField
            name="username"
            label="Username"
            fullWidth
            value={credentials.username}
            onChange={handleChange}
          />
          <TextField
            name="password"
            label="Password"
            type="password"
            fullWidth
            value={credentials.password}
            onChange={handleChange}
          />
          <Button variant="contained" color="primary" type="submit" fullWidth>
            Log In
          </Button>
        </Stack>
      </form>
    </Box>
  );
};

export default Login;
