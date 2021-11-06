import React, { Component } from 'react';
import { Route } from 'react-router';
import Container from '@material-ui/core/Container';
import CssBaseline from '@material-ui/core/CssBaseline';
import MenuTop from './components/MenuTop';
import Home from './components/Home';
import Product from './components/Product/index';
import EditProduct from './components/Product/Edit/index.js';

import { PRODUCT, EDIT_PRODUCT, AUTH } from "./constants/pages";
export default class App extends Component {
  displayName = App.name;
  render() {
    return (
       <React.Fragment>
        <CssBaseline />
        <MenuTop />
        <Container maxWidth="md">
           <Route exact path='/' component={Home} />
           <Route path='/home' component={Home} />
           <Route path={PRODUCT} component={Product} />
           <Route path={EDIT_PRODUCT} component={EditProduct} />
        </Container>
    </React.Fragment>
    );
  }
}
