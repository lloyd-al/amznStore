export default function authHeader() {
    // return authorization header with jwt token
    //const currentUser = authenticationService.currentUserValue;
    const user = JSON.parse(localStorage.getItem('currentUser'));

    if (user && user.Token) {
        return { 'Authorization': 'Bearer ' + user.Token };
    } else {
        return {};
    }
}