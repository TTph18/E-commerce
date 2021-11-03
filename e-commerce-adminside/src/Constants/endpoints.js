const Endpoints = {
    authorize: 'api/authorize',
    me: 'api/authorize/me',
    
    getAllProducts: 'api/Products/get-all-products',
    getProductByID: (id) => `api/Products/get-product-by-id/${id}`,

};

export default Endpoints;
