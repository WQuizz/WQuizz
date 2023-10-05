import React from "react";
import NavigationBar from "../Components/NavigationBar"; // Import your Navbar component
import { Outlet, Link } from "react-router-dom";
import Sidebar from "../Components/Sidebar";

const Layout = () => {
  return (
    <div className="Layout">
      <NavigationBar />
      <Sidebar/>
      <Outlet />
    </div>
  );
};

export default Layout;
