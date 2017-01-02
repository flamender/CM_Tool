import React, { Component } from 'react';
//import logo from '../public/favicon.ico';
import {JenkinsBuild} from '../components/JenkinsBuild'
import '../assets/stylesheets/App.css';
import { Navbar, NavItem, Nav } from 'react-bootstrap';

class App extends Component {
  render() {
    return (
      <div className="App">
        <div className="App-header">
        <Navbar inverse collapseOnSelect fluid  defaultExpanded >          
          <h2>Rigilog Configuration Tool</h2>
            <Navbar.Header>              
              <Navbar.Toggle />
            </Navbar.Header>
            <Navbar.Collapse>
              <Nav  onSelect={this.handleSelect}>
                <NavItem  eventKey={1}>Jenkins-Build</NavItem>
                <NavItem eventKey={2}>Feature Verwaltung</NavItem>                
                <NavItem eventKey={3}>Kunden Verwaltung</NavItem>
                <NavItem eventKey={4}>Modul Konfiguration</NavItem>
                <NavItem eventKey={5}>Paket Verwaltung</NavItem>
              </Nav>              
            </Navbar.Collapse>
          </Navbar>
          </div>
        </div>      
    );
  }
  
  handleSelect(selectedKey)
  {
      switch(selectedKey)
      {
          case 1:
              alert ('Jenlins');
              break;
          default:
      }
              
  }
}

export default App;
