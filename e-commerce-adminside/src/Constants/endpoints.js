const Endpoints = {
    authorize: 'api/authorize',
    me: 'api/authorize/me',
    
    brand: '/api/Products/',
    brandId: (id) => `api/Products/get-product-by-id/${id}`,

};

export default Endpoints;
