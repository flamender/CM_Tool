import React, { Component, PropTypes } from 'react';
import ReactDOM from 'react-dom';
import { connect } from 'react-redux';
import { Navbar, NavItem, Nav } from 'react-bootstrap';
//import logo from '../public/favicon.ico';
import '../assets/stylesheets/App.css';
import fetchCustomer from '../actions/customer';
import {selectedKey} from '../actions/app'; 
import JenkinsBuild  from '../components/JenkinsBuild';
import {ModuleAdministration, ModuleAdminVm} from '../components/ModuleAdministration'
import {PacketAdministration} from '../components/PacketAdministration';
import {FeatureAdministration} from '../components/FeatureAdministration';
import {CustomerAdministration} from '../components/CustomerAdministration';



class App extends Component {
    constructor(props) {         
        super(props);
        
               
    }


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
                  <Nav  onSelect= {this.handleSelect}>
                    <NavItem  eventKey={1}>Jenkins-Build</NavItem>
                    <NavItem eventKey={2}>Feature Verwaltung</NavItem>                
                    <NavItem eventKey={3}>Kunden Verwaltung</NavItem>
                    <NavItem eventKey={4}>Modul Verwaltung</NavItem>
                    <NavItem eventKey={5}>Paket Verwaltung</NavItem>
                  </Nav>              
                </Navbar.Collapse>
              </Navbar>
              </div>
              <div className ="curPage">
                  {this.getPageById()}
              </div>
            </div>      
      );
    }
     
    getPageById()
    {
        let id = key;
        switch(id)
        {
            case 1:                
                return <JenkinsBuild/>;
                break;
            case 2: 
                return <FeatureAdministration/>;
                break;
            case 3:
                ReactDOM.render(<CustomerAdministration/>,document.getElementById('rootPages'));
                break;
            case 4:
                ReactDOM.render(<ModuleAdministration vm={new ModuleAdminVm()} />, document.getElementById('rootPages'));
        break;
            case  5:              
              ReactDOM.render(<PacketAdministration/>,document.getElementById('rootPages'));
              break;
          default:
         }
      }


  handleSelect(id)
  {
    key = id;
   ReactDOM.unmountComponentAtNode(React.findDOMNode('curPage').parentNode);
   ReactDOM.render();   
  }
}

let  key = 1;
export default  connect(null, {selectedKey})(App)
