import React, { useState } from "react";

import ProductForm from '../ProductForm.js';
import { makeStyles } from '@material-ui/core/styles';

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
const CreateProductContainer = () => {
    const classes = useStyles();

  return (
    <div className={classes.root}>
    <div className='primaryColor text-title intro-x'>
        Create New Product
    </div>

    <div className='row'>
        <ProductForm />

      </div>
  </div>
  );
};

export default CreateProductContainer;