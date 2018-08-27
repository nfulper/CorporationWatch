import React, { Component } from 'react';

class Job extends Component {
    constructor() {
        super();
        this.state = {
            Job: {},
        };
    }

    componentWillMount() {
        console.log("Executing component will mount.");
        fetch('http://localhost:5000/api/Job')
            .then(results => {
                return results.json();
            })
            .then(data => {
                console.log("Mapping data.", data);

                this.setState({
                    Job: data
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

export default Job;