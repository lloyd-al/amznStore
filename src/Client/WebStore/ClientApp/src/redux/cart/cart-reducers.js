import CartInitialState from './cart-intialstate';
import CartActionTypes from './cart-types';
import { addItemToCart, removeItemFromCart } from './cart-utils';

const cartReducer = (state = CartInitialState, action) => {
    switch (action.type) {
        case CartActionTypes.ADD_ITEM:
            return {
                ...state,
                cartItems: addItemToCart(state.cartItems, action.payload),
            };
        case CartActionTypes.REMOVE_ITEM:
            return {
                ...state,
                cartItems: removeItemFromCart(state.cartItems, action.payload)
            };
        case CartActionTypes.CLEAR_ITEM_FROM_CART:
            return {
                ...state,
                cartItems: state.cartItems.filter(
                    cartItem => (
                        (cartItem.product.id !== action.payload.product.id) && (cartItem.size !== action.payload.size)
                    )
                )
            };
        default:
            return state;
    }
};

export default cartReducer;
