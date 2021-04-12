import CartActionTypes from './cart-types';

export const addItem = (product, size, quantity) => ({
    type: CartActionTypes.ADD_ITEM,
    payload: {
        product,
        size,
        quantity
    }
});

export const removeItem = (product, size, quantity) => ({
    type: CartActionTypes.REMOVE_ITEM,
    payload: {
        product,
        size,
        quantity
    }
});

export const clearItemFromCart = (product, size) => ({
    type: CartActionTypes.CLEAR_ITEM_FROM_CART,
    payload: {
        product,
        size
    }
});

export const emptyCart = () => ({
    type: CartActionTypes.EMPTY_CART
});