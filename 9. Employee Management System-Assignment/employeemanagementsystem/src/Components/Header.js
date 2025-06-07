import React from "react";
import { AppBar, Toolbar, Typography, Button } from "@mui/material";
import { NavLink } from "react-router-dom"; // Import NavLink for active styles

const Header = () => {
  return (
    <AppBar position="static">
      <Toolbar>
        <Typography variant="h6" style={{ flexGrow: 1 }}>
          Employee Management System
        </Typography>
        <Button component={NavLink} to="/SignUp" color="inherit" activeStyle={{ fontWeight: "bold", color: "yellow" }}>
          Sign Up
        </Button>
        <Button component={NavLink} to="/Login" color="inherit" activeStyle={{ fontWeight: "bold", color: "yellow" }}>
          Login
        </Button>
        <Button component={NavLink} to="/EmployeeForm" color="inherit" activeStyle={{ fontWeight: "bold", color: "yellow" }}>
          Employee Form
        </Button>
      </Toolbar>
    </AppBar>
  );
};

export default Header;
