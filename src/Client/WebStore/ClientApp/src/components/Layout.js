import React, { Component } from 'react';
import NavMenu from '../components/home/NavMenu';
import Footer from './home/Footer';

import './theme.css'
import './layout-style.css'

export class Layout extends Component {
    constructor(props) {
        super(props);

        this.state = {
            theme: 'light'
        };
    }

    render() {
        return (
            <div className={`Layout ${this.state.theme}`}>
                <NavMenu />
                {this.props.children}
                <Footer />
            </div>
        );
    }
}
