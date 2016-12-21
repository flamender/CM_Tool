import React, { Component } from 'react';
//import logo from './logo.svg';
//import logo from '../public/favicon.ico';
import './App.css';
import { Navbar, NavItem, Nav } from 'react-bootstrap';

class App extends Component {
  render() {
    return (
      <div className="App">
        <div className="App-header">
        <Navbar inverse collapseOnSelect fluid  expanded >          
          <h2>Rigilog Configuration Tool</h2>
            <Navbar.Header>              
              <Navbar.Toggle />
            </Navbar.Header>
            <Navbar.Collapse>
              <Nav>
                <NavItem  eventKey={1} href="#">Jenkins-Build</NavItem>
                <NavItem eventKey={2} href="#">Feature Verwaltung</NavItem>                
                <NavItem eventKey={3} href="#">Kunden Verwaltung</NavItem>
                <NavItem eventKey={3} href="#">Modul Konfiguration</NavItem>
                <NavItem eventKey={3} href="#">Paket Verwaltung</NavItem>
              </Nav>              
            </Navbar.Collapse>
          </Navbar>
          </div>
        </div>      
    );
  }
}

export default App;
