import { AxiosResponse } from "axios";
import qs from 'qs';

import RequestService from '../../../services/request';
import EndPoints from '../../../constants/endpoints';

export function createCategoryRequest(categoryForm) {
    const formData = new FormData();

    Object.keys(categoryForm).forEach(key => {
        formData.append(key, categoryForm[key]);
    });

    return RequestService.axios.post(EndPoints.createCategory, formData);
}   

export function getCategoryRequest() {
    return RequestService.axios.get(EndPoints.getAllCategories);
}

export function updateCategoryRequest(categoryForm) {
    const formData = new FormData();

    Object.keys(categoryForm).forEach(key => {
        formData.append(key, categoryForm[key]);
    });

    return RequestService.axios.put(EndPoints.updateCategoryByID(categoryForm.id ?? - 1), formData);
}

export function disableCategoryRequest(categoryId) {
    return RequestService.axios.delete(EndPoints.deleteCategoryByID(categoryId));
}