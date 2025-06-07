import React from "react";
import { Box, Typography } from "@mui/material";

const Footer = () => {
  return (
    <Box
      sx={{
        width: "100%",
        position: "fixed",
        bottom: 0,
        backgroundColor: "#1976d2",
        color: "white",
        textAlign: "center",
        py: 2,
      }}
    >
      <Typography variant="body2">
        © {new Date().getFullYear()} Employee Management System. All rights
        reserved.
      </Typography>
    </Box>
  );
};

export default Footer;
