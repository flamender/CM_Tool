import React, { Component } from 'react';
import { ControlLabel, FormControl, Button, ButtonGroup, MenuItem, DropdownButton, Form, FormGroup, HelpBlock, Checkbox,FieldGroup } from  'react-bootstrap';
import { ExDropdown } from './JenkinsBuild'
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/css/bootstrap-theme.css';
import '../assets/stylesheets/App.css';



const wellStyles = { maxWidth: 600, margin: '0 auto 10px' };

class ModuleAdministration extends Component {
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

export default ModuleAdministration;