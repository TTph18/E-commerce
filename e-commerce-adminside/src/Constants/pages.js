export const LOGIN = '/login';
export const AUTH = '/authentication/:action';
export const HOME = '/';

export const PRODUCT = '/Products';
export const CREATE_PRODUCT = '/Products/create';
export const EDIT_PRODUCT = '/Products/edit/:id';
export const EDIT_PRODUCT_ID = (id) => `/Products/edit/${id}`;

export const UNAUTHORIZE = '/unauthorize';
export const NOTFOUND = '/notfound';