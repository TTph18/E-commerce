import { AxiosResponse } from "axios";
import qs from 'qs';

import RequestService from '../../services/request';
import EndPoints from '../../constants/endpoints';

export function createProductRequest(productForm) {
    const formData = new FormData();

    Object.keys(productForm).forEach(key => {
        formData.append(key, productForm[key]);
    });

    return RequestService.axios.post(EndPoints.product, formData);
}

export function getProductRequest(query) {
    return RequestService.axios.get(EndPoints.getAllProducts, {
        params: query,
        paramsSerializer: params => qs.stringify(params),
    });
}

export function updateProductRequest(productForm) {
    const formData = new FormData();

    Object.keys(productForm).forEach(key => {
        formData.append(key, productForm[key]);
    });

    return RequestService.axios.put(EndPoints.productId(productForm.id ?? - 1), formData);
}

export function disableProductRequest(productId) {
    return RequestService.axios.delete(EndPoints.productId(productId));
}