import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { HomePage, ShopPage, ProductPage, CartPage } from './pages';

import './App-style.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
            <Route exact path='/' component={HomePage} />
            <Route path='/shop' component={ShopPage} />
            <Route path='/product' component={ProductPage} />
            <Route path='/cart' component={CartPage} />
      </Layout>
    );
  }
}
