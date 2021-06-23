import React, { useEffect }  from 'react'
import { connect } from 'react-redux';
import { compose } from 'redux';
import { Paper } from '@material-ui/core';
import { useFormik } from 'formik';
import CurrencyFormat from 'react-currency-format';
import * as Yup from 'yup';

import { selectCartItemsCount, selectCartTotal, selectDiscountedCartTotal } from '../../redux/cart/cart-selectors';
import { selectDiscountCode, checkDiscountImplemented, selectDiscountError } from '../../redux/discount/discount-selectors';
import { addDiscount, removeDiscount } from '../../redux/discount/discount-actions';

import PurchaseProjectImg from '../../assets/img_purchase_Protection.png';
import "./subtotal-style.css"

const SubTotal = (props) => {
    const { totalItems, totalAmount, totalDiscountedAmount, error, isDiscountImplemented, discountCode, addDiscount, removeDiscount } = props;

    const formik = useFormik({
        initialValues: {
            discountcode: ''
        },
        validationSchema: Yup.object().shape({
            discountcode: Yup.string()
                .min(5, "Invalid Discount Code.")
                .max(16, "Invalid Discount Code.")
                .required('Please Enter the Discount Code'),
        }),
        onSubmit: (values, { setSubmitting }) => {
            addDiscount(values.discountcode);
            setSubmitting(false);
        },
        validateOnChange: false,
        initialTouched: {},
        //onReset: (values, { resetForm }) => resetForm(),
    })

    useEffect(() => {
        const divElement = <div style={{ backgroundColor: 'lightpink', color: 'red', width: '60px' }}>{discountCode} <span style={{ color:'black', 'font-weight':'bold', 'cursor':'pointer' }} onClick={clearDiscount}>X</span></div>;

        if (error) {
            formik.setFieldError('discountcode', 'Invalid Coupon');
        } else {
            formik.setFieldError('discountcode', divElement);
            formik.setFieldValue('discountcode', '');
        }

    }, [error, isDiscountImplemented])

    const clearDiscount = () => {
        removeDiscount();
        formik.resetForm();
    }

    return (
        <div>
            <Paper className="subtotal_column" square={true}>
                <img className="purchase_protect" src={PurchaseProjectImg} alt="Purchase Protection" />
            </Paper>

            <Paper className="subtotal_column" square={true}>
                <div className="divDiscountSection">
                    <form onSubmit={formik.handleSubmit}>
                        <input type="text" id="discountcode" name="discountcode" className="txtDiscountCode" value={formik.values.discountcode} onChange={formik.handleChange} placeholder="Apply Discount Coupon" />
                        <button type="submit" disabled={formik.isSubmitting} className="btn_ApplyDiscount">
                            {formik.isSubmitting && <span className="spinner-border spinner-border-sm mr-1"></span>}Apply</button>
                        {formik.errors.discountcode && formik.touched.discountcode && (<div className="discountError">{formik.errors.discountcode}</div>)}
                    </form>
                </div>

                {  isDiscountImplemented ?
                    <div>
                        <CurrencyFormat
                            renderText={(value) => (
                                <>
                                    <p>Subtotal ({totalItems} items) : <strong>{`${value}`}</strong></p>
                                    <small className="subtotal__gift"><input type="checkbox" /> This order contains a gift</small>
                                </>
                            )}
                            value={totalDiscountedAmount}
                            displayType={'text'}
                            thousandSeparator={true}
                            prefix={'$'}
                        />
                    </div> :
                    <div>
                        <CurrencyFormat
                            renderText={(value) => (
                                <>
                                    <p>Subtotal ({totalItems} items) : <strong>{`${value}`}</strong></p>
                                    <small className="subtotal__gift"><input type="checkbox" /> This order contains a gift</small>
                                </>
                            )}
                            value={totalAmount}
                            displayType={'text'}
                            thousandSeparator={true}
                            prefix={'$'}
                        />
                    </div>
                }
                <div>
                    <button className="btn_CheckOut">Proceed to Buy</button>
                </div>
            </Paper>
        </div>
    )
}

const mapStateToProps = (state) => ({
    totalItems: selectCartItemsCount(state),
    totalAmount: selectCartTotal(state),
    totalDiscountedAmount: selectDiscountedCartTotal(state),
    isDiscountImplemented: checkDiscountImplemented(state),
    discountCode: selectDiscountCode(state),
    error: selectDiscountError(state)
});

const mapDispatchToProps = dispatch => ({
    addDiscount: (discount) => dispatch(addDiscount(discount)),
    removeDiscount: () => dispatch(removeDiscount()),
});

const withConnect = connect(mapStateToProps, mapDispatchToProps);

export default compose(withConnect)(SubTotal);