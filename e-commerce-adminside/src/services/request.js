import axios from 'axios';
import { UrlBackEnd } from "../constants/oidc-config";
import { 
    REQUEST_ACCESS_TOKEN_STORAGE_KEY
 } from "../constants/oidc-config";

const config = {
    baseURL: UrlBackEnd
}

class RequestService {
    axios;

    constructor() {
        this.axios = axios.create(config);
        let access_token = localStorage.getItem(REQUEST_ACCESS_TOKEN_STORAGE_KEY);
        if (access_token !== undefined) this.setAuthentication(access_token);

    }

    setAuthentication(accessToken) {
        this.axios.defaults.headers.common['Authorization'] = `Bearer ${accessToken}`;
    }
}

export default new RequestService();
