const Endpoints = {
    authorize: 'api/authorize',
    me: 'api/authorize/me',
    
    getAllProducts: 'api/Products/get-all-products',
    getProductByID: (id) => `api/Products/get-product-by-id/${id}`,
    updateProductByID: (id) => `api/Products/update-product-by-id/${id}`,
    createProduct: 'api/Products/add-product',
    deleteProductByID: (id) => `api/Products/delete-product-by-id/${id}`,

    getAllCategories: 'api/Categories/get-all-categories',
    getCategoriesByID: (id) => `api/Categories/get-category-by-id/${id}`,
    updateCategoryByID: (id) => `api/Categories/update-category-by-id/${id}`,
    createCategory: 'api/Categories/add-category',
    deleteCategoryByID: (id) =>`api/Categories/delete-category-by-id/${id}`,
};

export default Endpoints;
