export const LOGIN = '/login';
export const AUTH = '/authentication/:action';
export const HOME = '/';

export const PRODUCT = '/product';
export const CREATE_PRODUCT = '/product/create';
export const EDIT_PRODUCT = '/product/edit/:id';
export const EDIT_PRODUCT_ID = (id) => `/product/edit/${id}`;

export const UNAUTHORIZE = '/unauthorize';
export const NOTFOUND = '/notfound';