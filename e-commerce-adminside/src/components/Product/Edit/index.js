import React, { useEffect, useState } from 'react'
import * as Yup from 'yup';
import { Formik, Form } from 'formik';
import { makeStyles } from '@material-ui/core/styles';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import Alert from '@material-ui/lab/Alert';
import { Redirect, useParams, useLocation } from 'react-router';

import ProductForm from '../ProductForm.js';

const useStyles = makeStyles((theme) => ({
    root: {
        flexGrow: 1,
        marginTop: 20
    },
    paper: {
        padding: theme.spacing(2),
        margin: 'auto',
        maxWidth: 600,
    },
    title: {
        fontSize: 30,
        textAlign: 'center'
    },
    link: {
        padding: 10,
        display: 'inline-block'
    },
    txtInput: {
        width: '98%',
        margin: '1%'
    },
    submit: {
        margin: theme.spacing(3, 0, 2),
    },
}));
const EditProduct = () => {
    const classes = useStyles();

    const [product, setProduct] = useState(undefined);
    const {state} = useLocation();
    const { existProduct } = state; // Read values passed on state
    
    useEffect(() => {
      if (existProduct) {
        setProduct({
          id: existProduct?.id,
          name: existProduct?.name,
          price: existProduct?.price,
          description: existProduct?.description,
          pictureurl: existProduct?.pictureUrl,
          categoryID: existProduct?.categoryID
        });
      }
    }, [existProduct]);
  
    return (
      <div className={classes.root}>
        <div className='primaryColor text-title intro-x' style={{ textAlign: 'center'}}>
          Update Product {existProduct?.name}
        </div>
  
        <div className='row'>
          {
            product && (<ProductForm
              initialProductForm={product}
    
            />)
          }
        </div>
      </div>
    )
  };
  
  export default EditProduct;