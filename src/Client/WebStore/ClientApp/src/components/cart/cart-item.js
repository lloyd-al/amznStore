import React from 'react';
import { connect } from 'react-redux';
import { Grid } from '@material-ui/core';
import DeleteForeverTwoToneIcon from '@material-ui/icons/DeleteForeverTwoTone';
import { clearItemFromCart, addItem, removeItem } from '../../redux/cart/cart-actions';

import ImgAmznFullfilled from '../../assets/amzn_fulfilled.png'
import './cart-item-style.css';

const CartItem = ({ item, clearItem, addItem, removeItem }) => {
    const itemSize = item.size;

    return (
        <div className='cart-item'>
            <Grid item xs={12} container>
                <Grid item xs={3}>
                    <div><img className="itemImg" src={item.product.imageUrl} alt='item' /></div>
                </Grid>
                <Grid item xs={5}>
                    <div className="itemValue">
                        <div className="itemName">{item.product.productName}</div>
                        <div className="itemSubName">
                            <div>In Stock</div>
                            <div>Eligible for FREE Shipping</div>
                            <div><img src={ImgAmznFullfilled} /></div>
                            <div className="subtotal__gift"><input type="checkbox" />This will be a gift</div>
                        </div>
                    </div>
                </Grid>
                <Grid item xs={1}>
                    <div className="itemValue">{itemSize}</div>
                </Grid>
                <Grid item xs={1}>
                    <div className="itemValue">${item.product.currentPrice}</div>
                </Grid>
                <Grid item xs={1}>
                    <div className='itemValue'>
                        <span className='quantity'>
                            <span className='arrow' onClick={() => removeItem(item, itemSize, 1)}>&#10094;</span>
                            <span className='value'>{item.quantity}</span>
                            <span className='arrow' onClick={() => addItem(item, itemSize, 1)}>&#10095;</span>
                        </span>
                    </div>
                    <div className='remove-button' onClick={() => clearItem(item.product, itemSize)}><DeleteForeverTwoToneIcon /></div>
                </Grid>
                <Grid item xs={1}>
                    <div className="itemTotalValue">${item.quantity * item.product.currentPrice}</div>
                </Grid>
            </Grid>
            <div><hr /></div>
        </div>
    );
}

const mapDispatchToProps = dispatch => ({
    clearItem: (item, itemSize) => dispatch(clearItemFromCart(item, itemSize)),
    addItem: (item, itemSize) => dispatch(addItem(item.product, itemSize, 1)),
    removeItem: (item, itemSize) => dispatch(removeItem(item.product, itemSize, 1)),
});

export default connect(null, mapDispatchToProps)(CartItem);