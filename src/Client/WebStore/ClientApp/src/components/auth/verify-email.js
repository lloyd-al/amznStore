import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import queryString from 'query-string';
import { Alert } from '@material-ui/lab';
import CheckCircleOutlineIcon from '@material-ui/icons/CheckCircleOutline';

import { AuthenticationService } from '../../services/auth-service';

function VerifyEmail({ history }) {
    const EmailStatus = {
        Verifying: 'Verifying',
        Success: 'Success',
        Failed: 'Failed'
    }

    const [emailStatus, setEmailStatus] = useState(EmailStatus.Verifying);

    useEffect(() => {
        const { email, token } = queryString.parse(window.location.search);

        // remove token from url to prevent http referer leakage
        history.replace(window.location.pathname);

        AuthenticationService.verifyEmail(email, token)
            .then(() => {
                setEmailStatus(EmailStatus.Success);
                history.push('/auth/login');
            })
            .catch(() => {
                setEmailStatus(EmailStatus.Failed);
            });
    }, []); // eslint-disable-line react-hooks/exhaustive-deps

    function getBody() {
        switch (emailStatus) {
            case EmailStatus.Verifying:
                return <div>Verifying...</div>;
            case EmailStatus.Success:
                return (<div><Alert icon={<CheckCircleOutlineIcon fontSize="inherit" />} variant="outlined" severity="success">
                    Registration successful, please check your email for verification instructions</Alert></div>);
            case EmailStatus.Failed:
                return <div>Verification failed, you can also verify your account using the <Link to="/auth/forgot-password">forgot password</Link> page.</div>;
            default:
                return <div>Verifying...</div>;
        }
    }

    return (
        <div>
            <h3 className="register_confirmation">Verify Email</h3>
            <div className="verify_body">{getBody()}</div>
        </div>
    )
}

export default VerifyEmail;