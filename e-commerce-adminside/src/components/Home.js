import React, { useEffect, useState, lazy, Suspense } from 'react'
import { makeStyles } from '@material-ui/core/styles';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import Alert from '@material-ui/lab/Alert';
import { Redirect } from 'react-router-dom';
import IconButton from '@material-ui/core/IconButton';
import CloseIcon from '@material-ui/icons/Close';
import Button from '@material-ui/core/Button';
import { Link } from 'react-router-dom'
import Url from '../services/url';
import { GET_ALL_PRODUCTS, DELETE_PRODUCT_ID } from '../services/api-service';
import { getProductRequest } from "./services/request"
const ListProduct = lazy(() => import("./List"));

const useStyles = makeStyles((theme) => ({
    root: {
        flexGrow: 1,
        marginTop: 20
    },
    paper: {
        width: '100%',
        margin: 'auto'
    },
    removeLink: {
        textDecoration: 'none'
    }
}));
export default function Home() {
    const classes = useStyles();

    const [checkDeleteProduct, setCheckDeleteProduct] = useState(false);
    const [close, setClose] = React.useState(false);

    return (
        <div className={classes.root}>
            <Grid container spacing={3}>
                <Grid item xs={12}>
                    <Paper className={classes.paper}>
                        {checkDeleteProduct && <Alert
                            action={
                                <IconButton
                                    aria-label="close"
                                    color="inherit"
                                    size="small"
                                    onClick={() => {
                                        setClose(true);
                                        setCheckDeleteProduct(false)
                                    }}>
                                    <CloseIcon fontSize="inherit" />
                                </IconButton>
                            }
                        >Detele successfuly</Alert>}
                        
                        <Suspense fallback={<div>Loading..</div>}>
                        <ListProduct></ListProduct>
                        </Suspense>
                    </Paper>
                </Grid>
            </Grid>
        </div>
    )
}
