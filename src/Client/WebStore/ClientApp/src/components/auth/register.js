import React, { useState } from 'react'
import { Link, useHistory } from "react-router-dom"
import { Formik, Field, Form, ErrorMessage } from 'formik';
import * as Yup from 'yup';
import { Alert, AlertTitle } from '@material-ui/lab';
import ReportProblemOutlinedIcon from '@material-ui/icons/ReportProblemOutlined';

import { useTheme } from '../ThemeContext';
import { AuthenticationService } from '../../services/auth-service';

import blackLogo from '../../assets/amzn_black.png';
import whiteLogo from '../../assets/amzn_white.png';
import "./auth-style.css"

function Register ({ location }) {
    // Declare a new state variable, which we'll call "count"
    const [errCount, setErrCount] = useState(0);
    const history = useHistory();
    const themeState = useTheme();

    const initialValues = {
        firstname: '',
        lastname: '',
        phonenumber: '',
        email: '',
        password: '',
        confirmpassword: '',
        acceptterms: false
    };

    const validationSchema = Yup.object().shape({
        firstname: Yup.string()
            .required('First Name is required'),
        lastname: Yup.string()
            .required('Last Name is required'),
        phonenumber: Yup.string()
            .required('Phone Number is required')
            .matches(/^((\+[1-9]{1,4}[ -]?)|(\([0-9]{2,3}\)[ -]?)|([0-9]{2,4})[ -]?)*?[0-9]{3,4}[ -]?[0-9]{3,4}$/, "Incorrect Phone Number"),
        email: Yup.string()
            .email('Email is invalid')
            .required('Email is required'),
        password: Yup.string()
            .min(8, "Password is too short - should be 8 chars minimum.")
            .max(16)
            .matches(/^(?=.*[a-z])(?=.*[A-Z])(?=.*d)[a-zA-Zd]/, "Password must contain a number.")
            .required('Password is required'),
        confirmpassword: Yup.string()
            .required('Confirm Password is required')
            .oneOf([Yup.ref('password'), null], 'Passwords must match'),
        acceptterms: Yup.bool()
            .oneOf([true], 'Accept Terms & Conditions is required')

    });

    function onSubmit(fields, { setStatus, setSubmitting }) {
        console.log(fields);
        setStatus();
        AuthenticationService.register(fields)
            .then(() => {
                setErrCount(0);
                const { from } = location.state || { from: { pathname: "/auth/register-confirmation" } };
                history.push(from);
            })
            .catch(error => {
                setSubmitting(false);
                setErrCount(errCount + 1);
            });
    }

    return (
        <div className="register_body">
            <Link to="/">
                {themeState.darkMode
                    ? <img className="login__logo" src={blackLogo} alt="Amzn logo" />
                    : <img className="login__logo" src={whiteLogo} alt="Amzn logo" />
                }
            </Link>

            <Formik initialValues={initialValues} validationSchema={validationSchema} onSubmit={onSubmit}>
                {({ errors, touched, isSubmitting }) => (
                    <div>
                        {errCount > 0 && (
                            <div>
                                <Alert icon={<ReportProblemOutlinedIcon style={{ fontSize: 40 }} />} variant="outlined" severity="warning">
                                    <AlertTitle>there was a problem</AlertTitle>
                                    Incorrect Email Address or Password.
                                </Alert>
                                <br />
                            </div>
                        )}
                        <div className="login__container">
                            <h3>Create Account</h3>
                            <Form className="form-signin">
                                <div className="login__label">First Name</div>
                                <Field name="firstname" type="text" className={'form-control' + (errors.firstname && touched.firstname ? ' is-invalid' : '')} placeholder="" />
                                <ErrorMessage name="firstname" component="div" className="invalid-feedback" />

                                <div className="login__label">Last Name</div>
                                <Field name="lastname" type="text" className={'form-control' + (errors.lastname && touched.lastname ? ' is-invalid' : '')} placeholder="" />
                                <ErrorMessage name="lastname" component="div" className="invalid-feedback" />

                                <div className="login__label">Mobile Number</div>
                                <Field name="phonenumber" type="text" className={'form-control' + (errors.phonenumber && touched.phonenumber ? ' is-invalid' : '')} placeholder="" />
                                <ErrorMessage name="phonenumber" component="div" className="invalid-feedback" />

                                <div className="login__label">Email</div>
                                <Field name="email" type="text" className={'form-control' + (errors.email && touched.email ? ' is-invalid' : '')} placeholder="" />
                                <ErrorMessage name="email" component="div" className="invalid-feedback" />

                                <div className="login__label">Password</div>
                                <Field name="password" type="password" className={'form-control' + (errors.password && touched.password ? ' is-invalid' : '')} placeholder="" />
                                <ErrorMessage name="password" component="div" className="invalid-feedback" />

                                <div className="login__label">Confirm Password</div>
                                <Field name="confirmpassword" type="password" className={'form-control' + (errors.confirmpassword && touched.confirmpassword ? ' is-invalid' : '')} placeholder="" />
                                <ErrorMessage name="confirmpassword" component="div" className="invalid-feedback" />

                                <div className="form-group form-check-control">
                                    <Field type="checkbox" name="acceptterms" id="acceptterms" className={(errors.acceptterms && touched.acceptterms ? ' is-invalid' : '')} />
                                    <label htmlFor="acceptterms" className="form-check-label">&nbsp; Accept Terms & Conditions</label>
                                    <ErrorMessage name="acceptterms" component="div" className="invalid-feedback" />
                                </div>

                                <button type="submit" disabled={isSubmitting} className="login__signInBtn">
                                    {isSubmitting && <span className="spinner-border spinner-border-sm mr-1"></span>}
                                Continue
                            </button>
                            </Form>
                            <p className="login__legalstmt">
                                By signing in, you agree to Amazon's Condition of Use and Privacy Notice.
                        </p>
                        </div>
                    </div>

                )}
            </Formik>
            <div className="newact__label"><span>New to Amazon?</span></div>
            <button className="login__registerBtn">Create your Amazon account</button>
        </div>
    )
}
export default Register;