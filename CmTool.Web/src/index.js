import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import './index.css';
import './App.css';
import {JenkinsBuild} from './JenkinsBuild'
import ModuleAdministration from './ModuleAdministration'


class DropDownVm {
    constructor(caption, items) {
        this.caption = caption;
        this.items = items;
    }
}

class JenkinsVm {

    constructor() {
        this.customerDropDownVm = new DropDownVm("Kunde",
            [{ key: 1, value: "DEZA" }, { key: 2, value: "WF-MIGROS" }, { key: 3, value: "Wahler" }]
        );

        this.revsionDropDownVm = new DropDownVm("Revision", [{ key: 1, value: "4.0.0.8" }, { key: 2, value: "4.0.0.10" }])
        this.plattformDropDownVm = new DropDownVm("Plattform", [{ key: 1, value: "Test" }, { key: 2, value: "Integration" }, { key: 3, value: "Produktion" }])
        this.CurrentIstallationDropDownVm = new DropDownVm("Aktuell installierte Revision", [{ key: 1, value: "4.0.0.8" }, { key: 2, value: "4.0.0.10" }])
    }
};



class ModuleAdminVm {
    constructor() {
        this.jenkinsVm = new JenkinsVm();
        this.ModuleVm =  new DropDownVm("Modul", [{ key: 1, value: "Bill" }, { key: 2, value: "OAC" }])
    }
}



ReactDOM.render(
    <App />,
    document.getElementById('root')
);



ReactDOM.render(
    <table className="AppTable" >
        <body>
            <tr>
                <td>
                    <JenkinsBuild vm={new JenkinsVm()} />
                </td>
                <td>
                    <ModuleAdministration vm={new ModuleAdminVm()} />
                </td>
            </tr>
        </body>
    </table>
    , document.getElementById('root1')
);
