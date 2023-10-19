import React from "react";
import NavigationBar from "../Components/NavigationBar"; // Import your Navbar component
import { Outlet, Link } from "react-router-dom";
import Sidebar from "../Components/Sidebar";
import Footer from "./Footer";

const Layout = ({loggedIn, logOut}) => {
  return (
    <div className="Layout">
      <NavigationBar />
      <Sidebar loggedIn={loggedIn} logOut={logOut}/>
    
      <Outlet />
      
    </div>
  );
};

export default Layout;
