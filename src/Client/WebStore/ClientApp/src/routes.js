import React from "react";
import { Route, Switch } from "react-router-dom";
import { HomePage, ShopPage, ProductPage, CartPage } from './pages';
import { Register, Login, RegisterConfirmation, VerifyEmail } from './components/auth';

const ROUTES = [
    { path: "/", key: "ROOT", exact: true, component: HomePage },
    { path: "/home", key: "HOME", exact: true, component: HomePage },
    { path: "/shop", key: "SHOP", exact: false, component: ShopPage },
    { path: "/product", key: "PRODUCT", exact: false, component: ProductPage },
    { path: "/cart", key: "CART", exact: false, component: CartPage },
    {
        path: "/auth",
        key: "AUTH",
        component: RenderRoutes,
        routes: [
            {
                path: "/auth",
                key: "AUTH_ROOT",
                exact: true,
                component: Login
            },
            {
                path: "/auth/login",
                key: "AUTH_LOIGN",
                exact: false,
                component: Login
            },
            {
                path: "/auth/register",
                key: "AUTH_REGISTER",
                exact: false,
                component: Register
            },
            {
                path: "/auth/register-confirmation",
                key: "AUTH_REGISTER_CONFIRMATION",
                exact: false,
                component: RegisterConfirmation
            },
            {
                path: "/auth/verify-email",
                key: "AUTH_VERIFY_EMAIL",
                exact: false,
                component: VerifyEmail
            },
        ]
    },
];

export default ROUTES;

/**
 * Render a route with potential sub routes
 * https://reacttraining.com/react-router/web/example/route-config
 */
function RouteWithSubRoutes(route) {
    return (
        <Route
            path={route.path}
            exact={route.exact}
            render={props => <route.component {...props} routes={route.routes} />}
        />
    );
}

/**
 * Use this component for any new section of routes (any config object that has a "routes" property
 */
export function RenderRoutes({ routes }) {
    return (
        <Switch>
            {routes.map((route, i) => {
                return <RouteWithSubRoutes key={route.key} {...route} />;
            })}
            <Route component={() => <h1>Not Found!</h1>} />
        </Switch>
    );
}
