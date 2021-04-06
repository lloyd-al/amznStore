import React from 'react';
import { useLocation } from "react-router-dom";

import CategoryProducts from '../../components/catalog/category-products';

import './product-page-style.css';

const ProductPage = () => {
    let location = useLocation();
    console.log("Location");
    console.log(location);

    return (
        <div>
            <CategoryProducts categoryId={location.state.id} categoryName={location.state.categoryName} />
        </div>
    );
};


export default ProductPage;
