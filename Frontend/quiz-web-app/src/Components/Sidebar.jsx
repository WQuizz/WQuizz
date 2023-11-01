import React, { useState, useEffect } from 'react';
import { Navbar, Nav, NavDropdown } from 'react-bootstrap';
import "../Styles/sidebar.css";
import sidebarButton from '../Images/sidebar-button.png';
import homeIcon from '../Images/home-icon.png';
import categoriesIcon from '../Images/categories-icon.png';
import leaderboardsIcon from '../Images/leaderboards-icon.png';
import userIcon from '../Images/user-icon.png';
import {Link, NavLink} from 'react-router-dom';
import { fetchUserProfile } from "../Services/userServices";
import DisplayProfileImageElement from './DisplayProfileImageElement';


function Sidebar({loggedIn, logOut, userName, cookies, setLoggedIn, navigate, setUserName}) {

  const [isOpen, setIsOpen] = useState(false);
  const [userProfileTitle, setUserProfileTitle] = useState("User Profile");
  const [profilePicture, setProfilePicture] = useState(null);

  const toggleSidebar = () => {
    setIsOpen(!isOpen);
  };

  async function getUserProfilePic() {
      try {
        const user = await fetchUserProfile(userName);
        setUserProfileTitle(user.displayName);
        setProfilePicture(user.profilePicture);
      } catch (error) {
        // Handle any errors here, e.g., set a default picture
        console.error(error);
    }
  }

  useEffect(() => {
    if (userName !== null) {
      
      getUserProfilePic();
      
    }
    else{
      setUserProfileTitle("User Profile");
      setProfilePicture(null);
    }
  }, [userName]);

  return (
    <div className={`sidebar ${isOpen ? 'open' : 'closed'}`}>
      <Navbar expand="lg">
        <button onClick={toggleSidebar} className='toggle-button'><img src={sidebarButton}></img></button>
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="flex-column sidebar-items">
            <Nav.Item>
              <Nav.Link><NavLink className="custom-nav-link" to="/">{isOpen ?'Home': <img src={homeIcon}></img>}</NavLink></Nav.Link>
            </Nav.Item>
            <Nav.Item>
              <Nav.Link><NavLink className="custom-nav-link" to="/categories">{isOpen ?'Categories': <img src={categoriesIcon}></img>}</NavLink></Nav.Link>
            </Nav.Item>
            <Nav.Item>
              <Nav.Link className="custom-nav-link" href="#">{isOpen ?'Leaderboards': <img src={leaderboardsIcon}></img>}</Nav.Link>
            </Nav.Item>
            <Nav.Item>
                <Nav.Link>
            {
            isOpen ? (
            <>
              {userName&&
                <div className='avatar-container'>
                  <DisplayProfileImageElement profilePicture={profilePicture}/>
                </div> 
              }
              <NavDropdown
                title={userProfileTitle}
                id="basic-nav-dropdown"
                className="custom-dropdown"
              >
                {
                  loggedIn ? (
                    <>
                      <NavDropdown.Item href="#"><NavLink to={`profile/${userName}`} className="custom-nav-link">Profile</NavLink></NavDropdown.Item>
                      <NavDropdown.Item href="#">Settings</NavDropdown.Item>
                      <NavDropdown.Divider />
                      <NavDropdown.Item onClick={logOut(cookies, setLoggedIn, navigate, setUserName)}>Logout</NavDropdown.Item>
                    </>
                  ) :
                  (
                    <>
                      <NavDropdown.Item><NavLink to="login" className="custom-nav-link">Login</NavLink></NavDropdown.Item>
                      <NavDropdown.Item><NavLink to="registration" className="custom-nav-link">Register</NavLink></NavDropdown.Item>
                    </>
                  )
                }
              </NavDropdown>
              </>
            ): <img className='user-icon' src={userIcon}></img>}
            </Nav.Link>
              </Nav.Item>
           
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    </div>
  );
}

export default Sidebar;
