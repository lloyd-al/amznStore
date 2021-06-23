import { createSelector } from 'reselect';

const selectCart = state => state.cart;
const selectDiscount = state => state.discount;

export const selectCartItems = createSelector(
    [selectCart],
    cart => cart.cartItems
);

export const selectCartItemsCount = createSelector(
    [selectCartItems],
    cartItems =>
        cartItems.reduce(
            (accumalatedQuantity, cartItem) =>
                accumalatedQuantity + cartItem.quantity,
            0
        )
);

export const selectCartTotal = createSelector(
    [selectCartItems],
    cartItems =>
        cartItems.reduce(
            (accumalatedQuantity, cartItem) =>
                accumalatedQuantity + cartItem.quantity * cartItem.product.currentPrice,
            0
        )
);

export const selectDiscountedCartTotal = createSelector(
    [selectDiscount, selectCartTotal],
    (discountState, cartTotal) => {
        return (
            cartTotal - (cartTotal * (discountState.discount.discountPercentage / 100))
        );
    }
);