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

import CategoryForm from '../CategoryForm.js';

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
const EditCategory = () => {
    const classes = useStyles();

    const [category, setCategory] = useState(undefined);
    const {state} = useLocation();
    const { existCategory } = state; // Read values passed on state
    
    useEffect(() => {
      if (existCategory) {
        setCategory({
          id: existCategory?.id,
          name: existCategory?.name,
        });
      }
    }, [existCategory]);
  
    return (
      <div className={classes.root}>
        <div className='primaryColor text-title intro-x'>
          Update Category {existCategory?.name}
        </div>
  
        <div className='row'>
          {
            category && (<CategoryForm
              initialCategoryForm={category}
    
            />)
          }
        </div>
      </div>
    )
  };
  
  export default EditCategory;