import React, { Component, Suspense } from 'react';
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import Container from '@material-ui/core/Container';
import CssBaseline from '@material-ui/core/CssBaseline';
import MenuTop from './components/MenuTop';
import Home from './components/Home';
import Product from './components/Product/index';
import Category from './components/Category/index';
import Auth from './components/Auth/Auth';

import { PRODUCT, AUTH, CATEGORY } from "./constants/pages";


export default class App extends Component {
  displayName = App.name;
  render() {
    return (
      <Router>
        <div className="App"> 
        <CssBaseline />
        <MenuTop />
        <Container maxWidth="md">
          <Suspense fallback={<div>Loading..</div>}>
            <Switch>
              <Route exact path="/">
                <Home/>
              </Route>
              <Route path={PRODUCT}>
                <Product />
              </Route>
              <Route path={CATEGORY}>
                <Category />
              </Route>
              <Route path={AUTH}>
                <Auth />
              </Route>
          </Switch>
         </Suspense>
         </Container>
        </div>
      </Router>
    );
  }
}
