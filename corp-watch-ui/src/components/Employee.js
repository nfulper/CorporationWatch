import React, {
    Component
} from 'react';

class Employee extends Component {
    constructor() {
        super();
        this.state = {
            Employee: {},
        };
    }

    componentWillMount() {
        console.log("Executing component will mount.");
        fetch('http://localhost:5000/api/Employee')
            .then(results => {
                return results.json();
            })
            .then(data => {
                console.log("Mapping data.", data);
                
                this.setState({
                    Employee: data
                                });
                console.log("state", this.state.Employee)
            })
    }

    render() {
        return (

            <div className = "container1" >
           
            </div>
        )
    }
}

export default Employee;