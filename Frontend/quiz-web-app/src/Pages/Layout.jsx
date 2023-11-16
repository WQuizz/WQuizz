import React from "react";
import NavigationBar from "../Components/NavigationBar";
import { Outlet, useNavigate, useLocation } from "react-router-dom";
import Sidebar from "../Components/Sidebar";

const Layout = ({loggedIn, logOut, cookies, setLoggedIn, userName, setUserName}) => {
  const navigate = useNavigate();
  const location = useLocation();
  return (
    <div className="Layout">
      <NavigationBar />
      <Sidebar 
        loggedIn={loggedIn} logOut={logOut} cookies={cookies} setLoggedIn={setLoggedIn}
        userName={userName} navigate={navigate} setUserName={setUserName} location={location}
      />
      <Outlet />  
    </div>
  );
};

export default Layout;
