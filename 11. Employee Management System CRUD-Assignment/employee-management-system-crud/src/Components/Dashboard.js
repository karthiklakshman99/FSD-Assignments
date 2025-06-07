import React, { useContext, useEffect, useState } from "react";
import { Button, Card, CardContent, Typography } from "@mui/material";
import EmployeeContext from "../Context/EmployeeContext";
import { useNavigate } from "react-router-dom";

const Dashboard = () => {
  const { employees, deleteEmployee } = useContext(EmployeeContext);
  const navigate = useNavigate();

  const handleUpdate = (employee) => {
    navigate("/UpdateEmployee", { state: { employee } }); 
  };

  const handleDelete = (id) => {
    deleteEmployee(id);
    alert("Employee Deleted");
  };

  return (
    <div>
      <Typography variant="h4" sx={{ textAlign: "center", margin: "20px 0" }}>
        Employee Dashboard
      </Typography>
      <div style={{ display: "flex", flexWrap: "wrap", gap: "20px" }}>
        {employees.map((employee) => (
          <Card key={employee.id} sx={{ width: "300px" }}>
            <CardContent>
              <Typography variant="h5">{employee.name}</Typography>
              <Typography>{employee.designation}</Typography>
              <Typography>{employee.email}</Typography>
              <Button
                color="secondary"
                onClick={() => handleDelete(employee.id)}
              >
                Delete
              </Button>
              <Button
                color="primary"
                onClick={() => handleUpdate(employee)}
              >
                Update
              </Button>
            </CardContent>
          </Card>
        ))}
      </div>
    </div>
  );
};

export default Dashboard;
