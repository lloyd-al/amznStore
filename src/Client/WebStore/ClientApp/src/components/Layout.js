import React, { Component } from 'react';
import NavMenu from '../components/home/NavMenu';
import Footer from './home/Footer';

export class Layout extends Component {
    render() {
        return (
            <div>
                <NavMenu />
                {this.props.children}
                <Footer />
            </div>
        );
    }
}
