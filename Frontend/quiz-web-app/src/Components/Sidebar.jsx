import React, { useState } from 'react';
import { Navbar, Nav, NavDropdown } from 'react-bootstrap';
import "../Styles/sidebar.css";
import sidebarButton from '../Images/sidebar-button.png';
import homeIcon from '../Images/home-icon.png';
import categoriesIcon from '../Images/categories-icon.png';
import leaderboardsIcon from '../Images/leaderboards-icon.png';
import userIcon from '../Images/user-icon.png';

function Sidebar() {
  const [isOpen, setIsOpen] = useState(true);

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
              <Nav.Link href="#">{isOpen ?'Home': <img src={homeIcon}></img>}</Nav.Link>
            </Nav.Item>
            <Nav.Item>
              <Nav.Link href="#">{isOpen ?'Categories': <img src={categoriesIcon}></img>}</Nav.Link>
            </Nav.Item>
            <Nav.Item>
              <Nav.Link href="#">{isOpen ?'Leaderboards': <img src={leaderboardsIcon}></img>}</Nav.Link>
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
                <NavDropdown.Item href="#">Profile</NavDropdown.Item>
                <NavDropdown.Item href="#">Settings</NavDropdown.Item>
                <NavDropdown.Divider />
                <NavDropdown.Item href="#">Logout</NavDropdown.Item>
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