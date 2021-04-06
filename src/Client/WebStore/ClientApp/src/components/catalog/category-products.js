import React, { useEffect } from 'react';
import { connect } from 'react-redux';
import { compose } from 'redux';
import { createStructuredSelector } from 'reselect';
import { Grid } from '@material-ui/core';

import ProductItem from './product-item';
import { selectProductCollection, selectProductLoading, selectProductError } from '../../redux/product/productSelectors';
import { getCategoryProducts } from '../../redux/product/productActions';

import './product-item-style.css';

const CategoryProducts = (props) => {
    const { products, loading, error, categoryId, categoryName, getCategoryProducts } = props;

    useEffect(() => {
        getCategoryProducts(categoryId)
    }, [getCategoryProducts, categoryId])


    return (
        <div>
            { loading ? (
                <p> <em>Loading...</em></p >
            ) : error ? (
                <p><em>Oops... Something Went Wrong</em></p>
                ) : (
                        <div className="container">
                            <h2>{categoryName}</h2>
                            <Grid container item direction="row" justify="center" alignItems="center" xs={12} spacing={3} className="root">
                                {products
                                    .map(product => (
                                        <Grid item key={product.id} xs={3}>
                                            <ProductItem key={product.id} product={product} />
                                        </Grid>
                                    ))}
                            </Grid>
                        </div>
                    )
            }
        </div>
    );
};


const mapStateToProps = createStructuredSelector({
    products: selectProductCollection(),
    loading: selectProductLoading(),
    error: selectProductError()
});


const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        getCategoryProducts: categoryId => dispatch(getCategoryProducts(ownProps.categoryId))
    };
}

const withConnect = connect(mapStateToProps, mapDispatchToProps);

export default compose(withConnect)(CategoryProducts);
