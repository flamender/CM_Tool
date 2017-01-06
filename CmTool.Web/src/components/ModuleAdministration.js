import React, { Component } from 'react';
import { ControlLabel, FormControl, Button, ButtonGroup, MenuItem, DropdownButton, Form, FormGroup, HelpBlock, Checkbox,FieldGroup } from  'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/css/bootstrap-theme.css';
import '../assets/stylesheets/App.css';



export class JenkinsVm {

    constructor() {
        this.customerDropDownVm = new DropDownVm('Kunde',
            [{ key: 1, value: 'DEZA' }, { key: 2, value: 'WF-MIGROS' }, { key: 3, value: 'Wahler' }]
        );

        this.revsionDropDownVm = new DropDownVm('Revision', [{ key: 1, value: '4.0.0.8' }, { key: 2, value: '4.0.0.10' }])
        this.plattformDropDownVm = new DropDownVm('Plattform', [{ key: 1, value: 'Test' }, { key: 2, value: 'Integration' }, { key: 3, value: 'Produktion' }])
        this.CurrentIstallationDropDownVm = new DropDownVm('Aktuell installierte Revision', [{ key: 1, value: '4.0.0.8' }, { key: 2, value: '4.0.0.10' }])
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
          <DropdownButton id='1' title='--Select--' type='submit'>
            {entries}
          </DropdownButton>
        </td>
      </tr>
    )
  }
}


export class ModuleAdminVm {
    constructor() {          
        this.jenkinsVm = new JenkinsVm();
        this.ModuleVm =  new DropDownVm("Modul", [{ key: 1, value: "Bill" }, { key: 2, value: "OAC" }])
    }
};


export class DropDownVm {
    constructor(caption, items) {
        this.caption = caption;
        this.items = items;
    }
};



const wellStyles = { maxWidth: 600, margin: '0 auto 10px' };

export class ModuleAdministration extends Component {
    constructor(props) {
        super(props);
        this.state = props.vm;
    }
    render() {
        return (
            <div className="Well" style={wellStyles}>
                <fieldset>
                    <legend>Module Administration</legend>
                    <div className="ModuleAdministration">
                        <table>                            
                                <tr>
                                    <form>
                                        <FormGroup controlId="formBasicText">
                                            <ControlLabel>Konfiguration Speichern</ControlLabel>
                                            <td>
                                             <Button>Speichern</Button>
                                            </td>
                                            <td>
                                                <FormControl
                                                    type="text"
                                                    value={this.state.value}
                                                    placeholder="Enter text"                                                    
                                                    />
                                                <FormControl.Feedback />
                                            </td>
                                        </FormGroup>
                                    </form>
                                </tr>
                                <ExDropdown vm={this.state.jenkinsVm.customerDropDownVm}/>
                                <ExDropdown vm={this.state.jenkinsVm.revsionDropDownVm} />
                                <ExDropdown vm={this.state.ModuleVm} />
                                <ExDropdown vm={this.state.jenkinsVm.plattformDropDownVm} />
                                <tr>                                    
                                                                          
                                            <Checkbox inline> GUID</Checkbox>
                                            {' '}
                                            <Checkbox inline>Neu</Checkbox>
                                            {' '}
                                            <Checkbox inline>Geändert</Checkbox>
                                            {' '}
                                            <Checkbox inline>Beibehalten</Checkbox>
                                                                         
                                </tr>                       
                        </table>
                    </div>
                </fieldset>
            </div>
        )
    }
}

/*
     />
*/

