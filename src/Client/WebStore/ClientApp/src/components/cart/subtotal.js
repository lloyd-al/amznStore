import React from 'react'
import { connect } from 'react-redux';
import { Paper } from '@material-ui/core';
import CurrencyFormat from 'react-currency-format';
import { selectCartItemsCount, selectCartTotal } from '../../redux/cart/cart-selectors';

import PurchaseProjectImg from '../../assets/img_purchase_Protection.png';

import "./subtotal-style.css"

const SubTotal = ({ totalItems, totalAmount }) => {
    return (
        <div>
            <Paper className="subtotal_column" square={true}>
                <img className="purchase_protect" src={PurchaseProjectImg} alt="Purchase Protection" />
            </Paper>

            <Paper className="subtotal_column" square={true}>
                <div>
                    <CurrencyFormat
                        renderText={(value) => (
                            <>
                                <p>Subtotal ({totalItems} items) : <strong>{`${value}`}</strong></p>
                                <small className="subtotal__gift"><input type="checkbox" /> This order contains a gift</small>
                            </>
                        )}
                        value={totalAmount}
                        displayType={'text'}
                        thousandSeparator={true}
                        prefix={'$'}
                    />
                </div>
                <div>
                    <button className="btn_CheckOut">Proceed to Buy</button>
                </div>
            </Paper>
        </div>
    )
}

const mapStateToProps = state => ({
    totalItems: selectCartItemsCount(state),
    totalAmount: selectCartTotal(state)
});

export default connect(mapStateToProps, null)(SubTotal);