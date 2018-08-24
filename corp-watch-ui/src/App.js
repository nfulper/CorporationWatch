import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import './components/Employee.js';
import Employee from './components/Employee.js';

class App extends Component {
  render() {
    return (
      <div className="App">
          <Employee />
      </div>
    );
  }
}

export default App;
