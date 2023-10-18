import React, { useState } from 'react';
import { Navbar, Nav, NavDropdown } from 'react-bootstrap';
import "../Styles/sidebar.css";
import sidebarButton from '../Images/sidebar-button.png';
import homeIcon from '../Images/home-icon.png';
import categoriesIcon from '../Images/categories-icon.png';
import leaderboardsIcon from '../Images/leaderboards-icon.png';
import userIcon from '../Images/user-icon.png';
import {Link, NavLink} from 'react-router-dom';

function Sidebar({loggedIn, logOut}) {
  const [isOpen, setIsOpen] = useState(false);

  
function Sidebar({loggedIn, logOut}) {
  const [isOpen, setIsOpen] = useState(true);
function Sidebar() {
  const [isOpen, setIsOpen] = useState(false);

  
  const toggleSidebar = () => {
    setIsOpen(!isOpen);
  };

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
              <NavDropdown
                title="User Profile"
                id="basic-nav-dropdown"
                className="custom-dropdown"
              >
                {
                  loggedIn ? (
                    <>
                      <NavDropdown.Item href="#">Profile</NavDropdown.Item>
                      <NavDropdown.Item href="#">Settings</NavDropdown.Item>
                      <NavDropdown.Divider />
                      <NavDropdown.Item onClick={logOut}>Logout</NavDropdown.Item>
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