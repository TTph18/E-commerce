import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Paper from '@material-ui/core/Paper';
import { makeStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import { Link } from 'react-router-dom'
import Url from '../../services/url';
import { GET_ALL_PRODUCTS, DELETE_PRODUCT_ID } from '../../services/api-service';
import {
    ACCSENDING,
    DECSENDING,
    DEFAULT_PAGE_LIMIT,
} from '../../constants/paging';

import { getProductRequest } from "../services/request"

const useStyles = makeStyles((theme) => ({
    root: {
      flexGrow: 1,
      marginTop:20
    },
    paper:{
      width:'100%',
      margin:'auto'
    },
    removeLink:{
      textDecoration:'none'
    }
  }));

const ListProduct = () => {
    const classes = useStyles();

    const [products, setProducts] = useState(null);
    const [query, setQuery] = useState({
        page: 1,
        limit: DEFAULT_PAGE_LIMIT,
        sortOrder: DECSENDING,
    });

    const RawHTML = (description, className) =>
        <div className={className} dangerouslySetInnerHTML={{ __html: description.replace(/\n/g, '<br />') }} />

    useEffect(() => {
        GET_ALL_PRODUCTS().then((response) => {
            setProducts(response.data.items);
        });
    }, []);

    if (!products) return null;
    return (
        <div>
            <Link to="/create" type="button" className="btn btn-success">
                Create new Brand
            </Link>
            {/* <Button variant="success">Create</Button> */}
            <TableContainer component={Paper}>
                            <Table className={classes.table} aria-label="simple table">
                                <TableHead>
                                    <TableRow>
                                        <TableCell>Name</TableCell>
                                        <TableCell align="center">Description</TableCell>
                                        <TableCell align="center">Price</TableCell>
                                        <TableCell align="center">Image</TableCell>
                                        <TableCell align="center">Rate</TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {products && products?.items?.map((row, index) => (
                                        <TableRow key={row.Id}>
                                            <TableCell component="th" scope="row">{row.name}</TableCell>
                                            <TableCell align="left">{RawHTML(row.description, "description")}</TableCell>
                                            <TableCell align="center">{row.price}$</TableCell>
                                            <img src={`${Url}${row.pictureUrl}`} align="center" width="50" height="50" marginTop="100"></img>
                                            <TableCell align="center">{row.rate}</TableCell>
                                            <TableCell align="center">
                                                <Link to={`/edit/product/${row.id}`} className={classes.removeLink}>
                                                    <Button size="small" variant="contained" color="primary">Edit</Button></Link>
                                            </TableCell>
                                            <TableCell align="center">

                                            </TableCell>
                                        </TableRow>
                                    ))}
                                </TableBody>
                            </Table>
                        </TableContainer>
        </div>
    );
};

export default ListProduct;
