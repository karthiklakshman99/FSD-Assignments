import React, { useState, useContext, useEffect } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { TextField, Button, Paper, Typography } from "@mui/material";
import EmployeeContext from "../Context/EmployeeContext";

const UpdateEmployee = () => {
  const { state } = useLocation();
  const navigate = useNavigate();
  const { updateEmployee } = useContext(EmployeeContext);
  const [formData, setFormData] = useState({
    id: "",
    name: "",
    designation: "",
    email: "",
  });

  useEffect(() => {
    if (state?.employee) {
      setFormData(state.employee); // Prefill form with employee details
    }
  }, [state]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({ ...prevData, [name]: value }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    updateEmployee(formData.id, formData);
    navigate("/Dashboard");
  };

  return (
    <Paper elevation={3} sx={{ p: 4, maxWidth: 400, margin: "50px auto" }}>
      <Typography variant="h4" textAlign="center" gutterBottom>
        Update Employee
      </Typography>
      <form onSubmit={handleSubmit}>
        <TextField
          name="name"
          label="Name"
          value={formData.name}
          onChange={handleChange}
          fullWidth
          margin="normal"
        />
        <TextField
          name="designation"
          label="Designation"
          value={formData.designation}
          onChange={handleChange}
          fullWidth
          margin="normal"
        />
        <TextField
          name="email"
          label="Email"
          value={formData.email}
          onChange={handleChange}
          fullWidth
          margin="normal"
        />
        <Button
          type="submit"
          variant="contained"
          color="warning"
          fullWidth
          sx={{ mt: 2 }}
        >
          Update Employee
        </Button>
      </form>
    </Paper>
  );
};

export default UpdateEmployee;
