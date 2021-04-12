import React from 'react';
import { Route } from 'react-router-dom';

import Cart from '../../components/cart/cart';
import CategoryProductsPage from '../product/category-products-page';

const CartPage = ({ match }) => (
    <div>
        <Route exact path={`${match.path}`} component={Cart} />
        <Route path={`${match.path}/checkout`} component={CategoryProductsPage} />
    </div>
);

export default CartPage;