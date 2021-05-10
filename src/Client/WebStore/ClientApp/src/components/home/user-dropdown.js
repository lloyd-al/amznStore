import React from 'react';
import { Link, useHistory } from 'react-router-dom';
import { AuthenticationService } from '../../services/auth-service';

import './user-dropdown-style.css';

const UserDropDown = (props) => {
    const { isLoggedIn } = props;
    const history = useHistory();

    const logout = () => {
        props.dropdownVisible(false);
        AuthenticationService.logout();
        history.push("/");
    }

    const login = () => {
        props.dropdownVisible(false);
        history.push("/auth/login");
    }

    return (
        <div className="user-dropdown">
            { isLoggedIn ? (
                <>
                    <div className="menu-divider"></div>
                    <div className="account-section">
                        <ul className="linklist-style">
                            <li className="title"><b>Your Account</b></li>
                            <li className="text"><Link to="/user/profile" onClick={() => { props.dropdownVisible(false); }}>Your Profile</Link></li>
                            <li className="text"><Link to="/user/order" onClick={() => { props.dropdownVisible(false); }}>Your Order</Link></li>
                            <li className="text"><Link to="" onClick={() => { props.dropdownVisible(false); }}>Your Wish List</Link></li>
                            <li className="text"><Link to="" onClick={() => { props.dropdownVisible(false); }}>Your Recommendations</Link></li>
                            <li className="text"><Link to="" onClick={() => { props.dropdownVisible(false); }}>Your Prime Membership</Link></li>
                            <li className="text"><Link to="" onClick={() => { props.dropdownVisible(false); }}>Your Prime Video</Link></li>
                            <li className="text"><Link to="" onClick={() => { props.dropdownVisible(false); }}>Your Subscribe & Save Items</Link></li>
                            <li className="text"><Link to="" onClick={() => { props.dropdownVisible(false); }}>Memberships & Subscriptions</Link></li>
                            <li className="text"><Link to="" onClick={() => { props.dropdownVisible(false); }}>Your Amazon Business Account</Link></li>
                            <li className="text"><Link to="" onClick={() => { props.dropdownVisible(false); }}>Your Seller Account</Link></li>
                            <li className="text"><Link to="" onClick={() => { props.dropdownVisible(false); }}>Manage Your Content and Devices</Link></li>
                            <li className="text"><Link to="" onClick={() => { props.dropdownVisible(false); }}>Switch Accounts</Link></li>
                            <li className="text"><Link to="" onClick={logout}>Sign-Out</Link></li>
                        </ul>
                    </div>
                </>
            ) : (
                    <>
                        <div className="login-section">
                            <button className="login__signInBtn" onClick={login}>Sign-In</button>
                            <div className="newcustomer-section">New Customer? <Link to="/auth/register" onClick={() => { props.dropdownVisible(false); }}>Start Here</Link></div>
                        </div>
                    </>
                )
            }
        </div>
    );
}

export default UserDropDown;