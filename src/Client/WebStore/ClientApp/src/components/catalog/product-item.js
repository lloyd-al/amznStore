import React from 'react';
import { connect } from 'react-redux';
import { withRouter, useHistory, Link } from 'react-router-dom';
import { makeStyles } from '@material-ui/core/styles';
import { Paper } from '@material-ui/core';

const useStyles = makeStyles((theme) => ({
    root: {
        flexGrow: 1,
    },
    paper: {
        height: 380,
        width: 260,
        padding: theme.spacing(3),
        marginLeft: theme.spacing(3),
        marginBottom: theme.spacing(5),
        position: 'relative',
        background: 'white',
        direction: 'column',
        textAlign: 'center',
        alignItems: 'center',
        justify: 'center',
        fontWeight: 400,
    },
    image: {
        height: 240,
        width: 200,
        cursor: 'pointer',
    },
    price: {
        textAlign: 'left',
        fontWeight: 300,
    },
    currentprice: {
        fontWeight: 500,
        color: '#800000',
    },
    originalprice: {
        textDecoration: 'line-through',
        marginRight: '10px',
        marginLeft: '5px',

    },
}));

const ProductItem = ({ product }) => {
    const classes = useStyles();
    let history = useHistory();

    const priceDetail = (cprice, oprice) => {
        if (oprice > cprice) {
            return (<div><span className={classes.currentprice}>${currentPrice}</span><span className={classes.originalprice}>${originalPrice}</span><span>Save ${(oprice - cprice)} ({(100-(Math.floor((cprice / oprice) * 100)))}%)</span></div>);
        } else {
            return (<div><span className={classes.currentprice}>${currentPrice}</span></div>);
        }
    } 

    const { id, productName, currentPrice, originalPrice, imageUrl } = product;

    return (
         <Paper className={classes.paper} square={true}>
            <div>
                <div to={`/product/${productName}`} onClick={() => history.push({ pathname: `/shop/${productName}`, state: { id, productName } })}>
                    <img src={imageUrl} alt={productName.toUpperCase()} className={classes.image}  />
                </div>
            </div>
            <div className={classes.price}>{priceDetail(currentPrice, originalPrice)}</div>
            <div>{productName}</div>
        </Paper>
    );
}

export default withRouter(ProductItem);

