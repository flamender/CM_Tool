import React, { Component } from 'react';
import { ControlLabel, FormControl, Button, ButtonGroup, MenuItem, DropdownButton, Form, FormGroup } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/css/bootstrap-theme.css';
import '../assets/stylesheets/App.css';

export class PacketAdministration extends Component {

    constructor(props) {
        super(props);
        this.state = props.vm;
    }
    render() { return(
        <div>
         <b>PacketAdministration</b>
        </div>
        );
    }
}


