import React, { useEffect, useState } from 'react';
import NavMenu from './home/NavMenu';
import Footer from './home/Footer';

import './ThemeContext.css';

const initialState = {
    dark: false,
    toggle: () => { },
};

const ThemeContext = React.createContext(initialState);
const useTheme = () => React.useContext(ThemeContext);

const useDarkMode = () => {
    const [themeState, setThemeState] = useState({
        dark: false,
        hasThemeMounted: false
    });

    //const defaultTheme = (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches && themeState.dark) ? true : false;

    useEffect(() => {
        const lsDark = localStorage.getItem("DARK_MODE") === "true";
        setThemeState({ ...themeState, dark: lsDark, hasThemeMounted: true });
    }, []);


    return [themeState, setThemeState];
};

const ThemeLayout = (props) => {
    const [themeState, setThemeState] = useDarkMode();

    if (!themeState.hasThemeMounted) {
        /*
          If the theme is not yet loaded we don't want to render
          this is just a workaround to avoid having the app rendering
          in light mode by default and then switch to dark mode while
          getting the theme state from localStorage
        */
        return <div />;
    }

    const toggle = () => {
        const dark = !themeState.dark;
        localStorage.setItem("DARK_MODE", JSON.stringify(dark));
        setThemeState({ ...themeState, dark });
    };


    return (
        <div className="Layout" data-theme={themeState.dark ? "dark" : "light"}>
            <ThemeContext.Provider value={{ darkMode: themeState.dark, toggle }}>
                <NavMenu />
                {props.children}
                <Footer />
            </ThemeContext.Provider>
        </div>

    );
}

export { ThemeLayout, useTheme };
