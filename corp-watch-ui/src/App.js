import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
//import './components/Employee.js';
import Employee from './components/Employee.js';
import Job from './components/Job';
//import Navbar from './components/Navbar';

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Corporation Watch</h1>
        </header>
        <Employee />
        <Job />
       
        </div>
    );
  }
}

export default App;
