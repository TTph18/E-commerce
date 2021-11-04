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

const ProductTable = ({
  products,
  handlePage,
  handleSort,
  sortState,
  fetchData,
}) => {
    const classes = useStyles();
    let list = [];
    if(products?.items != null)
    {
        const arr =  Object.values(products?.items);
        list = arr;
    }
    
    const RawHTML = (description, className) =>
    <div className={className} dangerouslySetInnerHTML={{ __html: description.replace(/\n/g, '<br />') }} />
     return (
        <>
            <TableContainer component={Paper}>
            
                            <Table className={classes.table} aria-label="simple table" 
                            page={{
                                currentPage: products?.currentPage,
                                totalPage: products?.totalPages,
                              }}>
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
                                    {products && list !=null && list[1].map((row) => (
                                        <TableRow key={row.id}>
                                            <TableCell component="th" scope="row">{row.name}</TableCell>
                                            <TableCell align="left">{row.description}</TableCell>
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
                        </>
    );

};
export default ProductTable;
