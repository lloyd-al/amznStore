import React from 'react';
import { useLocation } from "react-router-dom";

import ProductDescription from '../../components/catalog/product-description';

const ProductPage = () => {
    let location = useLocation();

    return (
        <div>
            <ProductDescription product={location.state.product} />
        </div>
    );
};

export default ProductPage;
