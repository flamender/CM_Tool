import React, { Component } from 'react';
import { ControlLabel, FormControl, Button, ButtonGroup, MenuItem, DropdownButton, Form, FormGroup } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/css/bootstrap-theme.css';
import '../assets/stylesheets/App.css';



export class DropDownVm {
    constructor(caption, items) {
        this.caption = caption;
        this.items = items;
    }
};

export class JenkinsVm {

    constructor() {
        this.customerDropDownVm = new DropDownVm('Kunde',
            [{ key: 1, value: 'DEZA' }, { key: 2, value: 'WF-MIGROS' }, { key: 3, value: 'Wahler' }]
        );

        this.revsionDropDownVm = new DropDownVm("Revision", [{ key: 1, value: "4.0.0.8" }, { key: 2, value: "4.0.0.10" }])
        this.plattformDropDownVm = new DropDownVm("Plattform", [{ key: 1, value: "Test" }, { key: 2, value: "Integration" }, { key: 3, value: "Produktion" }])
        this.CurrentIstallationDropDownVm = new DropDownVm("Aktuell installierte Revision", [{ key: 1, value: "4.0.0.8" }, { key: 2, value: "4.0.0.10" }])
    }
};


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
              <Button type="submit">Jekins Revisions-File erzeugen</Button>
              <Button  onClick={this.getApiData}>XmlHttp</Button>
            </table>
          </div>
        </fieldset>
      </div>
    );  
  }

  getApiData(){      
      var xhr = new XMLHttpRequest();
      xhr.onload = function(x,m)
            {               
              if(xhr.readyState === 4)
              {
                  alert(xhr.responseText);

              }
              else
              {
                console.log('Error Call Webservice')
              }
      }
      
      xhr.open('GET', 'http://localhost:51407/public/jenkins');  
      xhr.send();
   }

  componentDidMount() {
  }

  componentWillUnmount() {
  }

}

