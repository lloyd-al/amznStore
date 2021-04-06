import React, { useEffect } from 'react';
import { connect } from 'react-redux';
import { compose } from 'redux';
import { createStructuredSelector } from 'reselect';
import { Grid } from '@material-ui/core';

import { selectProductCollection, selectProductLoading, selectProductError, selectProductFilter } from '../../redux/product/productSelectors';
import { getAllProducts } from '../../redux/product/productActions';
import ProductItem from './product-item';
import Pagination from '../custom-elements/pagination';

import './product-item-style.css';

const ProductList = (props) => {
    const { productFilter, products, loading, error, getPagedProducts } = props;
    const { currentPage, totalPages, pageSize } = productFilter;

    useEffect(() => {
        getPagedProducts(currentPage, pageSize)
    }, [getPagedProducts, currentPage, pageSize])

    const handlePageClick = data => {
        getPagedProducts(data, pageSize)
    }

    return (
        <div>
            { loading ? (
                <p> <em>Loading...</em></p >
            ) : error ? (
                    <p><em>Oops... Something Went Wrong</em></p>
                ) : (
                        <div className="container">
                            <h2>Clothing</h2>
                            <Grid container item direction="row" justify="center" alignItems="center" xs={12} spacing={3} className="root">
                                {products
                                    .map(product => (
                                        <Grid item key={product.id} xs={3}>
                                            <ProductItem key={product.id} product={product} />
                                        </Grid>
                                    ))}
                            </Grid>
                            <div className="pagination">
                                <Pagination currentPage={currentPage} totalPages={totalPages} pageSize={pageSize} handlePagination={handlePageClick} />
                            </div>
                        </div>
                    )
            }
        </div>
    );
}

const mapStateToProps = createStructuredSelector({
    productFilter: selectProductFilter(),
    products: selectProductCollection(),
    loading: selectProductLoading(),
    error: selectProductError()
});


const mapDispatchToProps = dispatch => ({
        getPagedProducts: (currentPage, pageSize) => dispatch(getAllProducts(currentPage, pageSize))
});

const withConnect = connect(mapStateToProps, mapDispatchToProps);

export default compose(withConnect)(ProductList);