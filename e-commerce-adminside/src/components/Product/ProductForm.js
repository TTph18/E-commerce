import React, { useEffect, useState } from 'react';

import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import { Link, useHistory } from 'react-router-dom';
import { NotificationManager } from 'react-notifications';

import TextField from '@material-ui/core/TextField';
import { PRODUCT } from '../../constants/pages';
import FileUpload from '../../shared-components/FileUpload';
import { createProductRequest, updateProductRequest } from "./services/request";
import { getCategoryRequest } from "../Category/services/request";

const initialFormValues = {
    name: '',
    type: '',
    description: '',
    pictureUrl: undefined
};

const validationSchema = Yup.object().shape({
    name: Yup.string().required('Required'),
    type: Yup.string().required('Required'),
    description: Yup.string().required('Required')
});

const ProductFormContainer = ({ initialProductForm = {
    ...initialFormValues
} }) => {
    const [loading, setLoading] = useState(false);

    const isUpdate = initialProductForm.id ? true : false;

    const history = useHistory();

    const [category, setCategory] = useState(0);
    const [categories,setCategories] = useState({});

    const handleChangeCategory = (event) => {
        setCategory(event.target.value);
      };
    
    useEffect(() => {
        /* GET API CATEGORIES */
        getCategoryRequest().then(item=>{
          setCategories(item.data);
          console.log(categories);
        });
         
      }, [])
    

    const handleResult = (result, message) => {
        if (result) {
            NotificationManager.success(
                `${isUpdate ? 'Updated' : 'Created'} Successful Product ${message}`,
                `${isUpdate ? 'Update' : 'Create'} Successful`,
                2000,
            );

            setTimeout(() => {
                history.push(PRODUCT);
            }, 1000);

        } else {
            NotificationManager.error(message, 'Create failed', 2000);
        }
    }

    const updateProductAsync = async (form) => {
        console.log('update product async');
        let data = await updateProductRequest(form.formValues);
        if (data)
        {
            handleResult(true, data.name);
        }
    }

    const createProductAsync = async (form) => {  
        console.log('create product async');
        let data = await createProductRequest(form.formValues);
        if (data)
        {
            handleResult(true, data.name);
        }
    }

    return (
        <Formik
            initialValues={initialProductForm}
            enableReinitialize
            validationSchema={validationSchema}
            onSubmit={(values) => {
                setLoading(true);

                setTimeout(() => {
                    if (isUpdate) {
                        updateProductAsync({ formValues: values });
                    }
                    else {
                        createProductAsync({ formValues: values });
                    }

                    setLoading(false);
                }, 1000);
            }}
        >
            {(actions) => (
                <Form className='intro-y col-lg-6 col-12'>
                    <TextField 
                        name="name" 
                        label="Name" 
                        placeholder="input product name" 
                        isrequired 
                        disabled={isUpdate ? true : false} />
                    <TextField 
                        name="description" 
                        label="Description" 
                        placeholder="input product desccription" 
                        isrequired />
                    <TextField
                        id="outlined-select-currency-native"
                        name="idCategory"
                        select
                        value={category}
                        onChange={handleChangeCategory}
                        SelectProps={{
                            native: true,
                        }}
                        helperText="Please select your currency"
                        variant="outlined"
                    >
                        <option value="0">Choose category</option>
                        {categories.length > 0 && categories.map((option) => (
                            <option key={option.idCategory} value={option.idCategory}>
                                {option.name}
                            </option>
                        ))}
                    </TextField>

                    <FileUpload 
                        name="imageFile" 
                        label="Image" 
                        image={actions.values.imagePath} />
                    
                    <div className="d-flex">
                        <div className="ml-auto">
                            <button className="btn btn-danger"
                                type="submit" disabled={loading}
                            >
                                Save {(loading) && <img src="/oval.svg" className='w-4 h-4 ml-2 inline-block' />}
                            </button>

                            <Link to={PRODUCT} className="btn btn-outline-secondary ml-2">
                                Cancel
                            </Link>
                        </div>
                    </div>
                </Form>
            )}
        </Formik>
    );
}

export default ProductFormContainer;
