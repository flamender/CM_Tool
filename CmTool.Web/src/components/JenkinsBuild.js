import React, { Component } from 'react';
import { ControlLabel, FormControl, Button, ButtonGroup, MenuItem, DropdownButton, Form, FormGroup } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/css/bootstrap-theme.css';
import '../assets/stylesheets/App.css';


export class ExDropdown extends Component {
  constructor(props) {
    super(props);
    this.state = props.vm;
  }
  render() {
    const entries = this.state.items.map((item) => <MenuItem key={item.key}>{item.value}</MenuItem>);
    return (
      <tr>
        <th>{this.state.caption}</th>
        <td>
          <DropdownButton id="1" title="--Select--" type="submit">
            {entries}
          </DropdownButton>
        </td>
      </tr>
    )
  }
}

const wellStyles = { maxWidth: 500, margin: '0 auto 10px' };

export class JenkinsBuild extends Component {

  constructor(props) {
    super(props);
    this.state = props.vm;

  }
  render() {
    return (
      <div className="Well" style={wellStyles}>
        <fieldset>
          <legend>Jenkins-Build</legend>
          <div className="JenkinsBuild">
            <table>
              <ExDropdown vm={this.state.customerDropDownVm} />
              <ExDropdown vm={this.state.revsionDropDownVm} />
              <ExDropdown vm={this.state.plattformDropDownVm} />
              <ExDropdown vm={this.state.CurrentIstallationDropDownVm} />              
              <Button type="submit"    >Jekins Revisions-File erzeugen</Button>
              <Button  onClick={this.getComponent}>XmlHttp</Button>
            </table>
          </div>
        </fieldset>
      </div>
    );  
  }

  getComponent(){
      alert("dafdsf") ;
       var xhr = new XMLHttpRequest();
       xhr.onreadystatechange=function(x,m)
       {
           if(xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200)
           {
               alert(xhr.responseText);
           }
       }
       xhr.open('GET', 'http://localhost:51408/JenkinsController', true);  
   }

  componentDidMount() {
  }

  componentWillUnmount() {
  }

}

