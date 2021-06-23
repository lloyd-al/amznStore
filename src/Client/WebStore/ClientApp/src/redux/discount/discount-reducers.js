import DiscountActionTypes from './discount-types';

const INITIAL_STATE = {
    loading: false,
    hasError: false,
    isValid: false,
    error: '',
    discount: []
}

const DiscountReducers = (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case DiscountActionTypes.ADD_DISCOUNT:
            return {
                ...state,
                loading: true
            };

        case DiscountActionTypes.REMOVE_DISCOUNT:
            return {
                ...state,
                discount: [],
                isValid: false,
                loading: true
            };

        case DiscountActionTypes.DISCOUNT_SUCCESS:
            return {
                ...state,
                loading: false,
                hasError: false,
                isValid: true,
                discount: action.payload
            };

        case DiscountActionTypes.DISCOUNT_ERROR:
            return {
                ...state,
                loading: false,
                hasError: true,
                isValid: false,
                discount: [],
                error: action.payload
            };

        default:
            return state;
    }
}

export default DiscountReducers;