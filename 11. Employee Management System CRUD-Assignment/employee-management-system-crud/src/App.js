import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { EmployeeProvider } from "./Context/EmployeeContext";
import Header from "./Components/Header";
import Footer from "./Components/Footer";
import Dashboard from "./Components/Dashboard";
import EmployeeForm from "./Components/EmployeeForm";
import SignUp from "./Components/SignUp";
import Login from "./Components/Login";
import UpdateEmployee from "./Components/UpdateEmployee";

const App = () => (
  <EmployeeProvider>
       <Router>
          <Header />
          <Routes>
              <Route path="/SignUp" element={<SignUp />} />
              <Route path="/Login" element={<Login />} />
              <Route path="/Dashboard" element={<Dashboard />} />
              <Route path="/EmployeeForm" element={<EmployeeForm />} />
              <Route path="/UpdateEmployee" element={<UpdateEmployee />} />
              <Route path="*" element={<SignUp />} />
          </Routes>
          <Footer />
      </Router>
  </EmployeeProvider>
);

export default App;
