import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import NavDropdown from "react-bootstrap/NavDropdown";
import "bootstrap/dist/css/bootstrap.css";
import { ReactDOM } from "react";
import NavItem from "react-bootstrap/NavItem";
// import NavLink from "react-bootstrap/NavLink";
import {Link, NavLink} from 'react-router-dom';
import "../Styles/navbar.css";

function NavigationBar() {
  return (
    <div className="navbar-container">
    <Navbar
      bg="dark"
      variant="dark"
      expand="lg"
      className="me-auto my-2 my-lg-0 nav-bar"
      style={{
        width: "100vw",
        position: "fixed", // Set position to fixed
        top: 0, // Stick it to the top of the screen
        zIndex: "999",
      }}
    >
      <Container style={{ float: "right" }} fluid>
        <Navbar.Brand><NavLink to="/" className="custom-nav-link">W Quizz</NavLink></Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav"></Navbar.Collapse>
        <Nav.Item>
          <Nav.Link as={NavLink} to="/about-us" className="about-us">About Us</Nav.Link>
        </Nav.Item>
      </Container>
    </Navbar>
    </div>
    
  );
}

export default NavigationBar;
