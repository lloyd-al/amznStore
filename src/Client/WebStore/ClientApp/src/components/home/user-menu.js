import React, { useState, useEffect, useRef } from 'react';
import { Link } from 'react-router-dom';
import { AuthenticationService } from '../../services/auth-service';
import UserDropDown from './user-dropdown';

import './NavMenu-style.css';


function useDropdownVisible(initialIsVisible) {
    const [isDropdownVisible, setIsDropdownVisible] = useState(initialIsVisible);
    const ref = useRef(null);

    const handleHideDropdown = (event: KeyboardEvent) => {
        if (event.key === "Escape") {
            setIsDropdownVisible(false);
        }
    };

    const handleClickOutside = event => {
        if (ref.current && !ref.current.contains(event.target)) {
            setIsDropdownVisible(false);
        }
    };

    useEffect(() => {
        document.addEventListener("keydown", handleHideDropdown, true);
        document.addEventListener("click", handleClickOutside, true);
        return () => {
            document.removeEventListener("keydown", handleHideDropdown, true);
            document.removeEventListener("click", handleClickOutside, true);
        };
    }, []);

    return { ref, isDropdownVisible, setIsDropdownVisible };
}


const UserMenu = () => {
    const { ref, isDropdownVisible, setIsDropdownVisible } = useDropdownVisible(false);
    const [user, setUser] = useState(AuthenticationService.currentUser);

    useEffect(() => {
        setUser(AuthenticationService.userValue);
    });

    return (
        <>
            <div className="header__nav-option2" ref={ref}>
                <Link to="#" onClick={() => setIsDropdownVisible(value => !value)} className="header__link">
                    <div className="header__option">
                        <span className="header__optionLineOne">Hello {!user ? 'Guest' : user.firstName}</span>
                        <span className="header__optionLineTwo">Account & Lists</span>
                    </div>
                </Link>
                {isDropdownVisible ? <UserDropDown isLoggedIn={!user ? false : true} dropdownVisible={setIsDropdownVisible } /> : null}
            </div>

        </>
    );
}

export default UserMenu;