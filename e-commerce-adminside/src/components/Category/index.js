import React, { useEffect, useState, lazy, Suspense} from 'react'
import { makeStyles } from '@material-ui/core/styles';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import Alert from '@material-ui/lab/Alert';
import { Redirect } from 'react-router-dom';
import IconButton from '@material-ui/core/IconButton';
import CloseIcon from '@material-ui/icons/Close';
import Button from '@material-ui/core/Button';
import { Link } from 'react-router-dom'
import Url from '../../services/url';
import { CATEGORY, EDIT_CATEGORY, CREATE_CATEGORY } from '../../constants/pages';
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";

const ListCategory = lazy(() => import("./List"));
const UpdateCategory = lazy(() => import("./Edit"));
const CreateCategory = lazy(() => import("./Create"));

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
export default function Category() {
    const classes = useStyles();

    const [close, setClose] = React.useState(false);

    return (
        <Switch>
            <Route exact path={CATEGORY}>
                <div className={classes.root}>
                    <Grid container spacing={3}>
                        <Grid item xs={12}>
                            <Paper className={classes.paper}>
                                <Suspense fallback={<div>Loading..</div>}>
                                    <ListCategory></ListCategory>
                                </Suspense>
                            </Paper>
                        </Grid>
                    </Grid>
                </div>
            </Route>
            <Route exact path={EDIT_CATEGORY}>
                <UpdateCategory />
            </Route>
            <Route exact path={CREATE_CATEGORY}>
                <CreateCategory />
            </Route>
        </Switch>
        
    )
}
