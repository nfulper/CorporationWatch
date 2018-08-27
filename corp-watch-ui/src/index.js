import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import { Home, About, Login, Employee, Job } from './components';

class Index extends React.Component {
    render() {
        return (
            <Router>
                <div>
                    <Route exact path = "/" component = {App} />
                    <Route exact path = "/login" component = {Login} /> 
                    <Route exact path = "/home" component = {Home} />
                    <Route exact path = "/about" component = {About} />
                    <Route exact path = "/employee" component = {Employee} />
                    <Route exact path = "/job" component = {Job} />
                </div> 
            </Router>
        )
    }
}

ReactDOM.render(<Index />, document.getElementById('root'));
  

