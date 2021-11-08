import React, { useState, useEffect } from 'react';
import { useHistory } from "react-router";
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
import TableFooter from '@material-ui/core/TableFooter';
import TablePagination from '@material-ui/core/TablePagination';
import { Link } from 'react-router-dom'
import Url from '../../../services/url';
import {
    EDIT_PRODUCT_ID
} from '../../../constants/pages';

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
    const history = useHistory();
    let list = [];
    if(products?.items != null)
    {
        const arr =  Object.values(products?.items);
        list = arr;
    }

    
    const handleEdit = (id) => {
        const arr =  Object.values(products?.items);
        const existProduct =arr[1].find(item => item.id === Number(id));
        history.push(
            EDIT_PRODUCT_ID(id),
          {
            existProduct: existProduct
          }
        );
      };

     return (
         <>
             <TableContainer component={Paper}>
                 <Table className={classes.table} aria-label="simple table"
                     page={{
                         currentPage: products ?.currentPage,
                         totalPage: products ?.totalPages,
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
                         {products && list != null && list[1].map((row) => (
                             <TableRow key={row.id}>
                                 <TableCell component="th" scope="row">{row.name}</TableCell>
                                 <TableCell align="left">{row.description}</TableCell>
                                 <TableCell align="center">{row.price}$</TableCell>
                                 <img src={`${Url}${row.pictureUrl}`} align="center" width="50" height="50" marginTop="100"></img>
                                 <TableCell align="center">{row.rate}</TableCell>
                                 <TableCell align="center">
                                     {/*<Link to={`/edit/product/${row.id}`} className={classes.removeLink}>*/}
                                         <Button size="small" variant="contained" color="primary" onClick={() => handleEdit(row.id)}>Edit</Button>
                                 </TableCell>
                                 <TableCell align="center"> 
                                 </TableCell>
                             </TableRow>
                         ))}
                     </TableBody>
                     <TableFooter>
                         <TableRow>
                             <TablePagination
                                 rowsPerPageOptions={[5, 10, 25, { label: 'All', value: -1 }]}
                                 colSpan={3}
                                 count={list?.length}
                                 rowsPerPage={products?.limit}
                                 SelectProps={{
                                     inputProps: {
                                         'aria-label': 'rows per page',
                                     },
                                     native: true,
                                 }}
                             />
                         </TableRow>
                     </TableFooter>
                 </Table>
             </TableContainer>
         </>
    );

};
export default ProductTable;
