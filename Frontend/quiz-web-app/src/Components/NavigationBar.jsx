import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import NavDropdown from "react-bootstrap/NavDropdown";
import "bootstrap/dist/css/bootstrap.css";
import { ReactDOM } from "react";
import NavItem from "react-bootstrap/NavItem";
import NavLink from "react-bootstrap/NavLink";
import {Link} from 'react-router-dom';
import '../Styles/navbar.css';

function NavigationBar() {
  return (
    <Navbar
      bg="dark"
      variant="dark"
      expand="lg"
      className="me-auto my-2 my-lg-0 nav-bar"
      style={{
        width: "100vw",
        position: "absolute",
        zIndex: "999",
      }}
    >
      <Container style={{ float: "right" }} fluid>
        <Navbar.Brand><Link to="/">W Quizz</Link></Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav"></Navbar.Collapse>
        <Nav>
          <NavLink><Link to="/leaderboard">Global Leaderboard</Link></NavLink>
          <NavLink> <Link to="/auth">User Auth</Link></NavLink>
        </Nav>
      </Container>
    </Navbar>
  );
}

export default NavigationBar;
