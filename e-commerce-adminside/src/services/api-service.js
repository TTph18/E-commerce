import axios from 'axios';
import EndPoints from '../constants/endpoints';

export function callApi(endpoint, method, body) {
    return axios({
        url: process.env.REACT_APP_BACKEND_URL + endpoint,
        method,
        data: body,
        headers: {
            'Content-Type' : 'text/plain'
        },
    }).catch((e) => {
        console.log(e);
        console.log('apiService here-', body);
    });
}

export function GET_ALL_PRODUCTS() {
    return callApi(EndPoints.getAllProducts, "GET");
}
export function GET_PRODUCT_ID(id) {
    return callApi(EndPoints.getProductByID + "/" + id, "GET");
}
export function POST_ADD_PRODUCT(endpoint, data) {
    return callApi(endpoint, "POST", data);
}
export function PUT_EDIT_PRODUCT(endpoint, data) {
    return callApi(endpoint, "PUT", data);
}
export function DELETE_PRODUCT_ID(endpoint) {
    return callApi(endpoint, "DELETE");
}
export function GET_ALL_CATEGORY(endpoint) {
    return callApi(endpoint, "GET");
}
export function GET_CATEGORY_ID(endpoint, id) {
    return callApi(endpoint + "/" + id, "GET");
}
export function DELETE_CATEGORY_ID(endpoint) {
    return callApi(endpoint, "DELETE");
}
export function POST_ADD_CATEGORY(endpoint, data) {
    return callApi(endpoint, "POST", data);
}
export function PUT_EDIT_CATEGORY(endpoint, data) {
    return callApi(endpoint, "PUT", data);
}
