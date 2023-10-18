import React from "react";
import NavigationBar from "../Components/NavigationBar"; // Import your Navbar component
import { Outlet, Link } from "react-router-dom";
import Sidebar from "../Components/Sidebar";

const Layout = ({loggedIn, logOut, cookies, setLoggedIn, userName}) => {
  return (
    <div className="Layout">
      <NavigationBar />
      <Sidebar loggedIn={loggedIn} logOut={logOut(cookies, setLoggedIn)} userName={userName}/>
      <Outlet />
    </div>
  );
};

export default Layout;
