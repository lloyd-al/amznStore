import React from 'react';
import { connect } from 'react-redux';
import { withRouter } from 'react-router-dom';
import { makeStyles } from '@material-ui/core/styles';
import { Paper, Grid } from '@material-ui/core';
import CartItem from './cart-item';
import SubTotal from './subtotal';

import './cart-style.css';

const useStyles = makeStyles((theme) => ({
    root: {
        flexGrow: 1,
        marginTop: '10px',
        marginBottom: '10px',
    },
}));

const Cart = ({ cartItems, history, dispatch }) => {
    const classes = useStyles();

    return (
        <div className="cartMain">
            <Grid item xs={12} container className={classes.root}>
                <Grid item xs={9}>
                    <Paper className="cart-item" square={true}>
                        <div className="cart-item-align">
                            <div>
                                <h2>Shopping Cart</h2>
                            </div>
                            <div style={{width:'98%'}}>
                                <Grid item xs={12} container>
                                    <Grid item xs={9}>
                                        <div></div>
                                    </Grid>
                                    <Grid item xs={1}>
                                        <div className="cartLabel">Price</div>
                                    </Grid>
                                    <Grid item xs={1}>
                                        <div className="cartLabel">Quantity</div>
                                    </Grid>
                                    <Grid item xs={1}>
                                        <div className="cartLabel">Total Price</div>
                                    </Grid>
                                </Grid>
                            </div>
                            <div><hr /></div>
                            <div>
                                {cartItems.length ? (
                                    cartItems.map(cartItem => (
                                        <CartItem key={cartItem.product.id + cartItem.size} item={cartItem} />
                                    ))
                                ) : (
                                        <span className='empty-message'>Your cart is empty</span>
                                    )}

                            </div>
                        </div>
                    </Paper>
                </Grid>
                <Grid item xs={3}>
                    <SubTotal />
                </Grid>
            </Grid>
        </div>
    );

};

const mapStateToProps = ({ cart: { cartItems } }) => ({
    cartItems
});

export default withRouter(connect(mapStateToProps)(Cart));