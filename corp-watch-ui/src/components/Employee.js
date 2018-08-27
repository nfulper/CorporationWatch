import React, { Component } from 'react';
import AuthService from './AuthService';

class Employee extends Component {
    constructor() {
        super();
        this.state = {
            Employees: []
        };
        this.auth = new AuthService();
    }

    componentWillMount() {
        /*this.auth.*/fetch('http://localhost:5000/api/Employee')
            .then(results => {
                return results.json();
            })
            .then(data => {
                this.setState({
                    Employees: data
                });
            })
    }

    render() {
        return (
            <div className="container1" >
                {this.state.Employees.map(e => (
                    <div>
                        <h3>{e.firstName} {e.lastName}</h3>
                        <p>Jobs: {e.jobs}</p>
                        <p>Department: {e.department}</p>
                    </div>
                ))}
            </div>
        )
    }
}

export default Employee;