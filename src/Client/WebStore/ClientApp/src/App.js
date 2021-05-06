import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { HomePage, ShopPage, ProductPage, CartPage } from './pages';
import Login from './components/auth/Login';

import { AuthenticationService } from './services/auth-service'

import './App-style.css'

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);

        this.state = {
            currentUser: null
        };
    }

    componentDidMount() {
        AuthenticationService.currentUser.subscribe(x => this.setState({ currentUser: x }));
    }

  render () {
    return (
      <Layout>
            <Route exact path='/' component={HomePage} />
            <Route path='/home' component={HomePage} />
            <Route path='/shop' component={ShopPage} />
            <Route path='/product' component={ProductPage} />
            <Route path='/cart' component={CartPage} />
            <Route path='/login' component={Login} />
      </Layout>
    );
  }
}
