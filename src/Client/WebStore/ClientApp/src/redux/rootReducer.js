import { combineReducers } from 'redux';
import { persistReducer } from 'redux-persist';
import storage from 'redux-persist/lib/storage';

import categoryReducers from './category/categoryReducers';
import productReducers from './product/productReducers';
import cartReducers from './cart/cart-reducers';
import DiscountReducers from './discount/discount-reducers';

const persistConfig = {
    key: 'root',
    storage,
    whitelist: ['cart']
};


const rootReducer = combineReducers({
    categories: categoryReducers,
    products: productReducers,
    cart: cartReducers,
    discount: DiscountReducers,
});

export default persistReducer(persistConfig, rootReducer);