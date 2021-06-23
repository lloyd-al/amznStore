import React, { Component } from 'react';
import ROUTES, { RenderRoutes } from './routes';

import { AuthenticationService } from './services/auth-service'
import { ThemeLayout } from './components/ThemeContext';

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
        <ThemeLayout>
            <RenderRoutes routes={ROUTES} />
        </ThemeLayout>
    );
  }
}
