const Endpoints = {
    authorize: 'api/authorize',
    me: 'api/authorize/me',
    
    getAllProducts: 'api/Products/get-all-products',
    getProductByID: (id) => `api/Products/get-product-by-id/${id}`,
    updateProductByID: (id) => `api/Products/update-product-by-id/${id}`,

};

export default Endpoints;
