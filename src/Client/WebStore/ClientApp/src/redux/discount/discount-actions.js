import DiscountActionTypes from './discount-types';
import { amznApiInstance } from '../../axios-instance';

export const addDiscount = (discountCode) => async dispatch => {
    dispatch({ type: DiscountActionTypes.ADD_DISCOUNT });

    return amznApiInstance
        .get(`/discount/verifycoupon/${discountCode}`)
        .then(response => {
            const discount = response.data;
            dispatch(getDiscountSuccess(discount));
        })
        .catch(error => {
            console.log("Error....");
            dispatch(getDiscountError(error));
            return Promise.reject({ error });
        })
}

export const removeDiscount = () => ({
    type: DiscountActionTypes.REMOVE_DISCOUNT,
    payload: []
});

const getDiscountSuccess = discount => ({
    type: DiscountActionTypes.DISCOUNT_SUCCESS,
    payload: discount
});

const getDiscountError = error => ({
    type: DiscountActionTypes.DISCOUNT_ERROR,
    payload: error
});