import React, { useEffect, useState } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Paper from '@material-ui/core/Paper';
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import { Link, useHistory } from 'react-router-dom';
import { NotificationManager } from 'react-notifications';
import Grid from '@material-ui/core/Grid';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import { PRODUCT } from '../../constants/pages';
import FileUpload from '../../shared-components/FileUpload';
import { createProductRequest, updateProductRequest } from "./services/request";
import { getCategoryRequest } from "../Category/services/request";

const useStyles = makeStyles((theme) => ({
    root: {
      flexGrow: 1,
      marginTop:20
    },
    paper: {
      padding: theme.spacing(2),
      margin: 'auto',
      maxWidth: 600,
    },
    title:{
      fontSize:30,
      textAlign:'center'
    },
    link:{
      padding:10,
      display:'inline-block'
    },
    txtInput:{
      width:'98%',
      margin:'1%'
    },
    imgInput:{
        margin:'100%',
      },
    submit: {
      margin: theme.spacing(3, 0, 2),
    },
  }));
  
const initialFormValues = {
    name: '',
    type: '',
    description: '',
    pictureUrl: undefined
};

const validationSchema = Yup.object().shape({
    name: Yup.string().required('Required'),
    description: Yup.string().required('Required')
});

const ProductFormContainer = ({ initialProductForm = {
    ...initialFormValues
} }) => {
    const classes = useStyles();

    const [loading, setLoading] = useState(false);

    const isUpdate = initialProductForm.id ? true : false;

    const history = useHistory();

    const [idProduct,setIdProduct] = useState(0);
    const [title,setTitle] = useState(null)
    const [body,setBody] = useState(null)
    const [slug,setSlug] = useState(null)

    const [category, setCategory] = useState(0);
    const [categories,setCategories] = useState({});

    const handleChangeCategory = (event) => {
        setCategory(event.target.value);
      };
    
    useEffect(() => {
        async function fetchCategoryDataAsync() {
            let list = [];
            let result = await getCategoryRequest();
            if (result.data != null) {
                const arr = Object.values(result.data);
                list = arr;
            }
            setCategories(list[1]);
          }
          fetchCategoryDataAsync();

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
        console.log('update');
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
        <div className={classes.root}>
            <Grid container spacing={3}>
                <Grid item xs={12}>
                    <Paper className={classes.paper}>
                        <Formik
                            initialValues={initialProductForm}
                            enableReinitialize
                            validateOnChange={false}
                            validateOnBlur={false}
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
                                <Form className='intro-y col-lg-6 col-12'
                                >
                                    <Grid item xs={12} sm container>
                                        <Grid item xs={12}>
                                            <TextField
                                            className={classes.txtInput}
                                                name="name"
                                                label="Name"
                                                value={initialProductForm.name}
                                                placeholder="input product name"
                                                isrequired
                                                disabled={isUpdate ? true : false} />
                                        </Grid>
                                        <Grid item xs={12}>
                                            <TextField
                                            className={classes.txtInput}
                                                name="description"
                                                label="Description"
                                                placeholder="input product description"
                                                isrequired />
                                        </Grid>
                                        <Grid item xs={12}>
                                            <TextField
                                            className={classes.txtInput}
                                                id="outlined-select-currency-native"
                                                name="idCategory"
                                                select
                                                value={category}
                                                onChange={handleChangeCategory}
                                                SelectProps={{
                                                    native: true,
                                                }}
                                                helperText="Please select category"
                                                variant="outlined"
                                            >
                                                <option value="0">Choose category</option>
                                                {categories.length > 0 && categories.map((option) => (
                                                    <option key={option.idCategory} value={option.idCategory}>
                                                        {option.name}
                                                    </option>
                                                ))}
                                            </TextField>
                                        </Grid>
                                        <Grid item xs={12}>
                                            <FileUpload
                                                className={classes.imgInput}
                                                name="imageFile"
                                                label="Image"
                                                image={actions.values.imagePath} />
                                        </Grid>
                                    </Grid>
                                    <div className="d-flex">
                                        <div className="ml-auto">
                                            <Button 
                                                type="submit" disabled={loading}
                                                className={classes.submit}
                                            >
                                                Save {(loading) && <img src="/oval.svg" className='w-4 h-4 ml-2 inline-block' />}
                                            </Button>

                                            <Link to={PRODUCT} className="btn btn-outline-secondary ml-2">
                                            <Button 
                                                className={classes.submit}
                                            >
                                                </Button>
                                                Cancel
                                            </Link>
                                        </div>
                                    </div>
                                </Form>
                            )}
                        </Formik>
                    </Paper>
                </Grid>
            </Grid>
        </div>
        
    );
}

export default ProductFormContainer;
