function parseJwt(token) {
    var payload = JSON.parse(atob(token.split('.')[1]));
    return payload;
};