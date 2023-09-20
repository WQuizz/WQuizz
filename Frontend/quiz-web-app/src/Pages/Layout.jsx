import React from "react";
import NavigationBar from "../Components/NavigationBar"; // Import your Navbar component
import { Outlet, Link } from "react-router-dom";

const Layout = () => {
  return (
    <div className="Layout">
      <NavigationBar />
      <Outlet />
    </div>
  );
};

export default Layout;
