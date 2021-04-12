import React from 'react';
import { connect } from 'react-redux';

import { selectCartItemsCount } from '../../redux/cart/cart-selectors';

import cart from '../../assets/cart.png';
import './cart-icon-style.css';

const CartIcon = ({ itemCount }) => {
    return (
        <div className="optionBasket">
            <span className="basketCount">{itemCount}</span>
            <img className="cart" src={cart} alt="Shopping Cart" />
        </div>
    );
}

const mapStateToProps = state => ({
    itemCount: selectCartItemsCount(state)
});

export default connect(mapStateToProps, null)(CartIcon);