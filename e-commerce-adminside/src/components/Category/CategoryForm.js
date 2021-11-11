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
import { CATEGORY } from '../../constants/pages';
import { createCategoryRequest, updateCategoryRequest } from "./services/request";

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
};

const validationSchema = Yup.object().shape({
    name: Yup.string().required('Required'),
});

const CategoryFormContainer = ({ initialCategoryForm = {
    ...initialFormValues
} }) => {
    const classes = useStyles();

    const [loading, setLoading] = useState(false);

    const isUpdate = initialCategoryForm.id ? true : false;

    const history = useHistory();

    const [idCategory,setIdCategory] = useState(0);
    const [title,setTitle] = useState(null)

    const [category, setCategory] = useState(0);

    const handleChangeCategory = (event) => {
        setCategory(event.target.value);
      };
      
    const handleResult = (result, message) => {
        if (result) {
            NotificationManager.success(
                `${isUpdate ? 'Updated' : 'Created'} Successful Category ${message}`,
                `${isUpdate ? 'Update' : 'Create'} Successful`,
                2000,
            );

            setTimeout(() => {
                history.push(CATEGORY);
            }, 1000);

        } else {
            NotificationManager.error(message, 'Create failed', 2000);
        }
    }

    const updateCategoryAsync = async (form) => {
        console.log('update category async');
        let data = await updateCategoryRequest(form.formValues);
        if (data)
        {
            handleResult(true, data.name);
        }
        console.log('update');
    }

    const createCategoryAsync = async (form) => {  
        console.log('create category async');
        let data = await createCategoryRequest(form.formValues);
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
                            initialValues={initialCategoryForm}
                            enableReinitialize
                            validateOnChange={false}
                            validateOnBlur={false}
                            validationSchema={validationSchema}
                            onSubmit={(values) => {
                                setLoading(true);

                                setTimeout(() => {
                                    if (isUpdate) {
                                        updateCategoryAsync({ formValues: values });
                                    }
                                    else {
                                        createCategoryAsync({ formValues: values });
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
                                                value={actions.values.name}
                                                onChange={actions.handleChange('name')}
                                                placeholder="input category name"
                                                variant="outlined"
                                                isrequired
                                                />
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

                                            <Link to={CATEGORY} className="btn btn-outline-secondary ml-2">
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

export default CategoryFormContainer;
