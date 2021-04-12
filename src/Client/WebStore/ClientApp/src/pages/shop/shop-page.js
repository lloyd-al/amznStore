import React from 'react';
import { Route } from 'react-router-dom';

import ProductList from '../../components/catalog/product-list';
import CategoryProductsPage from '../product/category-products-page';

const ShopPage = ({ match }) => (
    <div>
        <Route exact path={`${match.path}`} component={ProductList} />
        <Route path={`${match.path}/:categoryName`} component={CategoryProductsPage} />
    </div>
);

export default ShopPage;