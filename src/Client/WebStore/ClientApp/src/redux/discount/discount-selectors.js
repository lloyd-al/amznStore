import { createSelector } from 'reselect';

const selectDiscount = state => state.discount;

export const selectDiscountCode = createSelector(
    [selectDiscount],
    discountState => {
        return (discountState.discount.couponCode)
    }
);

export const checkDiscountImplemented = createSelector(
    [selectDiscount],
    discountState => {
        return (discountState.isValid)
    }
);

export const selectDiscountError = createSelector(
    [selectDiscount],
    discountState => discountState.hasError
);