﻿import React from 'react';
import Button from '@material-ui/core/Button';
import ClickAwayListener from '@material-ui/core/ClickAwayListener';
import Grow from '@material-ui/core/Grow';
import Paper from '@material-ui/core/Paper';
import Popper from '@material-ui/core/Popper';
import MenuItem from '@material-ui/core/MenuItem';
import MenuList from '@material-ui/core/MenuList';
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme) => ({
    root: {
        display: 'flex',
    },
    paper: {
        marginRight: theme.spacing(2),
    },
}));

function UserProfileMenu() {
    const classes = useStyles();

    return (
        <div>
            <div>
                <Link to="/login" onClick={ShowUserProfile} className="header__link">
                    <div className="header__option">
                        <span className="header__optionLineOne">Hello {!user ? 'Guest' : user.firstName}</span>
                        <span className="header__optionLineTwo">Account & Lists</span>
                    </div>
                </Link>
            </div>
        </div>
    );
}

export default UserProfileMenu;