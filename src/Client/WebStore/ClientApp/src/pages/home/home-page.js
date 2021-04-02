import React from 'react';
import Banners from '../../components/common/Banners';
import Categories from '../../components/catalog/category';

import "./home-page-style.css";

const HomePage = () => {
    return (
        <div className="home">
            <Banners />
            <Categories />
        </div>
    );
}
export default HomePage;
