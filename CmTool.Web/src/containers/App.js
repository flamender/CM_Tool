import 'babel-polyfill';
import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import { Navbar, NavItem, Nav } from 'react-bootstrap';
//import logo from '../public/favicon.ico';
import '../assets/stylesheets/App.css';
import {getCustomer} from '../actions/customer';

import {JenkinsBuild ,JenkinsVm } from '../components/JenkinsBuild';
import {ModuleAdministration, ModuleAdminVm} from '../components/ModuleAdministration'
import {PacketAdministration} from '../components/PacketAdministration';
import {FeatureAdministration} from '../components/FeatureAdministration';
import {CustomerAdministration} from '../components/CustomerAdministration';







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
                <NavItem eventKey={4}>Modul Verwaltung</NavItem>
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
              ReactDOM.render(<JenkinsBuild getCustomer={getCustomer} />, document.getElementById('root1'));
              break;
          case 2: 
              ReactDOM.render(<FeatureAdministration/>,document.getElementById('root1'));
              break;
          case 3:
              ReactDOM.render(<CustomerAdministration/>,document.getElementById('root1'));
              break;
         case 4:
              ReactDOM.render(<ModuleAdministration vm={new ModuleAdminVm()} />, document.getElementById('root1'));
              break;
          case  5:              
              ReactDOM.render(<PacketAdministration/>,document.getElementById('root1'));
              break;
          default:
      }              
  }
}

export default App;
