import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';

import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
export const UserContext = React.createContext({ username: "Tuan" });

const rootElement = document.getElementById('root');
ReactDOM.render(
  <BrowserRouter>
  <UserContext.Provider value={{ username: "T" }}>
    <App />
    </UserContext.Provider>,
  </BrowserRouter>,
  rootElement);


// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
