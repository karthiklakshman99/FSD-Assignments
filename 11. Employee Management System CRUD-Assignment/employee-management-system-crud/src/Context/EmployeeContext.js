import React, { createContext, useState, useEffect } from "react";
import axios from "axios";

const EmployeeContext = createContext();

export const EmployeeProvider = ({ children }) => {
  const [employees, setEmployees] = useState([]);
  const [users, setUsers] = useState([]);

  useEffect(() => {
    fetchEmployees();
    fetchUsers();
  }, []);

  const fetchEmployees = async () => {
    try {
      const response = await axios.get("http://localhost:3001/employees");
      setEmployees(response.data);
    } catch (error) {
      console.error("Error fetching employees:", error);
    }
  };

  const fetchUsers = async () => {
    try {
      const response = await axios.get("http://localhost:3001/users");
      setUsers(response.data);
    } catch (error) {
      console.error("Error fetching users:", error);
    }
  };

  const addUser = async (user) => {
    try {
      const response = await axios.post("http://localhost:3001/users", user);
      setUsers([...users, response.data]);
    } catch (error) {
      console.error("Error adding user:", error);
    }
  };

  const addEmployee = async (employee) => {
    try {
      const response = await axios.post("http://localhost:3001/employees", employee);
      setEmployees([...employees, response.data]);
    } catch (error) {
      console.error("Error adding employee:", error);
    }
  };

  const updateEmployee = async (id, updatedEmployee) => {
    try {
      const response = await axios.put(`http://localhost:3001/employees/${id}`, updatedEmployee);
      setEmployees(employees.map((emp) => (emp.id === id ? response.data : emp)));
    } catch (error) {
      console.error("Error updating employee:", error);
    }
  };

  const deleteEmployee = async (id) => {
    try {
      await axios.delete(`http://localhost:3001/employees/${id}`);
      setEmployees(employees.filter((emp) => emp.id !== id));
    } catch (error) {
      console.error("Error deleting employee:", error);
    }
  };

  return (
    <EmployeeContext.Provider
      value={{
        employees,
        users,
        addUser,
        addEmployee,
        updateEmployee,
        deleteEmployee,
      }}
    >
      {children}
    </EmployeeContext.Provider>
  );
};

export default EmployeeContext;
