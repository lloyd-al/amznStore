import React, { useState } from 'react';
import { connect } from 'react-redux';
import { makeStyles } from '@material-ui/core/styles';
import { Paper, Grid } from '@material-ui/core';

import { addItem } from '../../redux/cart/cart-actions';

import './product-description-style.css';

const useStyles = makeStyles((theme) => ({
    root: {
        flexGrow: 1,
        marginTop: '10px',
        marginBottom: '10px',
    },
}));

const ProductDescription = ({ product, addItem }) => {
    const { currentPrice, originalPrice, variantDetails } = product;
    const classes = useStyles();
    const [size, setSize] = useState("");
    const [quantity, setQuantity] = useState(1);
    const [errorMessage, setErrorMessage] = useState("");

    const priceDetail = (cprice, oprice) => {
        if (oprice > cprice) {
            return (<div className="productPrice">Price:<span className="currentprice">${currentPrice}</span><span className="originalprice">${originalPrice}</span><span>Save ${(oprice - cprice)} ({(100 - (Math.floor((cprice / oprice) * 100)))}%)</span></div>);
        } else {
            return (<div ><span className="currentprice">${currentPrice}</span></div>);
        }
    }

    const OnSizeChange = (e) => {
        setSize(e.target.value);

        if (e.target.value === "") {
            setErrorMessage("Please Select the Size");
        }
        else {
            setErrorMessage("");
        }
    }

    const AddToCart = (e) => {
        if (size === "") {
            setErrorMessage("Please Select the Size");
        }
        else {
            addItem(product, size, quantity);
        }
    }

    return (
        <div className="productMain">
            <Grid item xs={12} container className={ classes.root }>
                <Grid item xs={5}>
                    <div>
                        <div className="productImage">
                            <img src={product.imageUrl} alt={product.productName.toUpperCase()} />
                            </div>
                        </div>
                </Grid>
                <Grid item xs={4}>
                    <div className="productDescription">
                        <div style={{width:'100%'}}>
                            <h4>{product.summary}</h4>
                        </div>
                        <div><hr /></div>
                        <div>
                            {priceDetail(product.currentPrice, product.originalPrice) }
                        </div>
                        <div className="productSize">
                            Size: <select onChange={OnSizeChange}>
                                    <option value="">Select</option>
                                {variantDetails.map(variants => (
                                    <option key={variants.variant}>{variants.variant}</option>
                                ))}
                                </select>
                        </div>
                        <div className="productDetail">
                            {product.description}
                        </div>
                    </div>
                </Grid>
                <Grid item xs={3}>
                    <Paper className="buy_column">
                        <div>
                            {errorMessage && <div className="errorMessage">{ errorMessage} </div>}
                            To Buy, Select Size
                        </div>
                        <div>
                            Quantity : <select onChange={(e) => setQuantity(e.target.value)}>
                                {[...Array(20)].map((e, i) => (
                                    <option key={i + 1}>{i + 1}</option>
                                ))}
                            </select>
                        </div>
                        <div>
                            <button className="btn_AddCart" onClick={AddToCart}>Add To Cart</button>
                        </div>
                        <div>
                            <button className="btn_BuyNow" onClick={() => addItem(product, "fs", 2)}>Buy Now</button>
                        </div>
                    </Paper>
                </Grid>
            </Grid>
            <Grid item xs={12} container className={classes.root}>
                <Grid item xs={12}>
                    <div>
                        <hr />
                    </div>
                </Grid>
            </Grid>
        </div>
    );
}

const mapDispatchToProps = dispatch => ({
    addItem: (product, size, quantity) => dispatch(addItem(product, size, quantity))
});

export default connect(null, mapDispatchToProps)(ProductDescription);

