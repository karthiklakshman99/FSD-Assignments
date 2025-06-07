import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Header from "./Components/Header";
import Footer from "./Components/Footer";
import Login from "./Components/Login";
import EmployeeForm from "./Components/EmployeeForm";
import SignUp from "./Components/SignUp";

const App = () => {
  return (
    <Router>
      <Header />
      <Routes>
        <Route path="/SignUp" element={<SignUp />} />
        <Route path="/Login" element={<Login />} />
        <Route path="/EmployeeForm" element={<EmployeeForm />} />
      </Routes>
      <Footer />
    </Router>
  );
};

export default App;
