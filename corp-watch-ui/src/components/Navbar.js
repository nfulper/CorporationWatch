/*import React from 'react';
import { Link, Navlink } from 'react-router-dom';

const Navbar = ({ title }) => (
    <div>
        <h1>{title}</h1>
        <a href="/">Home | </a>
        <a href = "/about" >About</a>
        <a href = "/Employee" > Employees </a> 
        <a href = "/Job" > Jobs </a>
    </div>
)


export default Navbar;
*/
import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './Navbar.css';

export class NavMenu extends Component {
  displayName = NavMenu.name

  render() {
    return (
      <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <Link to={'/'}>Testing123</Link>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
          <Nav>
            <LinkContainer to={'/'} exact>
              <NavItem>
                <Glyphicon glyph='home' /> Home
              </NavItem>
            </LinkContainer>
            <LinkContainer to={"/about"}>
              <NavItem>
                <Glyphicon glyph='education' /> About
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/employee'}>
              <NavItem>
                <Glyphicon glyph='th-list' /> Employees
              </NavItem>
            </LinkContainer>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}

export default Navbar;