import React from 'react';
import { useLocation } from "react-router-dom";

import CategoryProducts from '../../components/catalog/category-products';

import './category-products-page-style.css';

const CategoryProductsPage = () => {
    let location = useLocation();

    return (
        <div>
            <CategoryProducts categoryId={location.state.id} categoryName={location.state.categoryName} />
        </div>
    );
};

export default CategoryProductsPage;
