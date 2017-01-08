import React, { Component } from 'react';
import { connect } from 'react-redux';
import _ from 'lodash';
import { ControlLabel, FormControl, Button, ButtonGroup, MenuItem, DropdownButton, Form, FormGroup } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/css/bootstrap-theme.css';
import '../assets/stylesheets/App.css';



const wellStyles = { maxWidth: 500, margin: '0 auto 10px' };



export default class JenkinsBuild extends Component {    
    constructor(props) {         
      super(props);
  }
  

  render() {
      return (      
      <div className='Well' style={wellStyles}>
        <fieldset>
          <legend>Jenkins-Build</legend>
          <div className='JenkinsBuild'>
            <table>              
              <Button type='submit'>Jekins Revisions-File erzeugen</Button>
            </table>
          </div>
        </fieldset>
      </div>
    );  
  }
  

  componentDidMount() {
  }  
  componentWillUnmount() {
  }
}

