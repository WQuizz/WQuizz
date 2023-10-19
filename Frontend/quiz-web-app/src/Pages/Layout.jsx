import React from "react";
import NavigationBar from "../Components/NavigationBar"; // Import your Navbar component
import { Outlet, Link, useNavigate } from "react-router-dom";
import Sidebar from "../Components/Sidebar";

const Layout = ({loggedIn, logOut, cookies, setLoggedIn, userName, setUserName}) => {
  const navigate = useNavigate();
  return (
    <div className="Layout">
      <NavigationBar />
      <Sidebar 
        loggedIn={loggedIn} logOut={logOut} cookies={cookies} setLoggedIn={setLoggedIn}
        userName={userName} navigate={navigate} setUserName={setUserName}
      />
      <Outlet />
    </div>
  );
};

export default Layout;
