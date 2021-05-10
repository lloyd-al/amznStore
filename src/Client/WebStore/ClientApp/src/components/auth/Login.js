import React, { useState } from 'react'
import { Link, useHistory } from "react-router-dom"
import { Formik, Field, Form, ErrorMessage } from 'formik';
import * as Yup from 'yup';
import { Alert, AlertTitle } from '@material-ui/lab';
import ReportProblemOutlinedIcon from '@material-ui/icons/ReportProblemOutlined';

import { AuthenticationService } from '../../services/auth-service';

import "./auth-style.css"

function Login({ location }) {
    // Declare a new state variable, which we'll call "count"
    const [errCount, setErrCount] = useState(0);
    const history = useHistory();

    const initialValues = {
        email: '',
        password: ''
    };

    const validationSchema = Yup.object().shape({
        email: Yup.string()
            .email('Email is invalid')
            .required('Email is required'),
        password: Yup.string()
            .min(8, "Password is too short - should be 8 chars minimum.")
            .max(16)
            .matches(/^(?=.*[a-z])(?=.*[A-Z])(?=.*d)[a-zA-Zd]/, "Password must contain a number.")
            .required('Password is required')
    });

    function onSubmit({ email, password }, { setSubmitting }) {
        AuthenticationService.login(email, password)
            .then(() => {
                setErrCount(0);
                const { from } = location.state || { from: { pathname: "/home" } };
                history.push(from);
            })
            .catch(error => {
                setSubmitting(false);
                setErrCount(errCount + 1);
            });
    }

    return (
        <div className="login">
            <Link to="/">
                <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/a/a9/Amazon_logo.svg/1024px-Amazon_logo.svg.png" alt="" className="login__logo" />
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
                            <br/>
                        </div>
                        )}
                    <div className="login__container">
                        <h3>Sign-In</h3>
                            <Form className="form-signin">
                            <div className="login__label">Email</div>
                                <Field name="email" type="text" className={'form-control' + (errors.email && touched.email ? ' is-invalid' : '')} placeholder="" />
                            <ErrorMessage name="email" component="div" className="invalid-feedback" />

                            <div className="login__label">Password</div>
                                <Field name="password" type="password" className={'form-control' + (errors.email && touched.email ? ' is-invalid' : '')} placeholder="" />
                            <ErrorMessage name="password" component="div" className="invalid-feedback" />
                            <button type="submit" disabled={isSubmitting} className="login__signInBtn">
                                {isSubmitting && <span className="spinner-border spinner-border-sm mr-1"></span>}
                                Sign-In
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
export default Login