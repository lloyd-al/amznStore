import CategoryActionTypes from './categoryTypes';
import { amznApiInstance } from '../../axios-instance';

export const getAllCategories = () => async dispatch => {
    dispatch({ type: CategoryActionTypes.GET_ALL_CATEGORY_REQUEST });

    return amznApiInstance
            .get('/Category')
            .then(response => {
                const categories = response.data;
                dispatch(getCategorySuccess(categories));
            })
            .catch(error => {
                dispatch(getCategoryError(error));
                return Promise.reject({ error });
        })
}

const getCategorySuccess = categories => ({
    type: CategoryActionTypes.GET_ALL_CATEGORY_SUCCESS,
    payload: categories
});

const getCategoryError = error => ({
    type: CategoryActionTypes.GET_ALL_CATEGORY_ERROR,
    payload: error
});