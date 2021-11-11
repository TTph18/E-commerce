import React, { useState, useEffect } from 'react';
import { useHistory } from "react-router";
import axios from 'axios';
import Paper from '@material-ui/core/Paper';
import { makeStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import Alert from '@material-ui/lab/Alert';
import CloseIcon from '@material-ui/icons/Close';
import IconButton from '@material-ui/core/IconButton';
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
import { deleteProductRequest } from "../services/request"

import {
    EDIT_PRODUCT_ID,
    DELETE_PRODUCT_ID
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
    const [checkDeleteProduct,setCheckDeleteProduct] = useState(false);
    const [close, setClose] = useState(false);

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

      const handleDelete = async (id)=>{
          let isSuccess = await deleteProductRequest(id);
          if (isSuccess) {
              await setCheckDeleteProduct(true);
          }
      };
    

     return (
         <>
         {checkDeleteProduct && <Alert
                  action={
                  <IconButton
                    aria-label="close"
                    color="inherit"
                    size="small"
                    onClick={() => {
                      setClose(true);
                      setCheckDeleteProduct(false)
                    }}
                  >
                    <CloseIcon fontSize="inherit" />
                  </IconButton>
                }
                >Detele successfuly</Alert>}

            
                
                     <TableHead>
                         <TableRow>
                             <TableCell>Name</TableCell>
                             <TableCell align="center">Description</TableCell>
                             <TableCell align="center">Price</TableCell>
                             <TableCell align="center">Image</TableCell>
                             <TableCell align="center">Rate</TableCell>
                             <TableCell align="center">Category</TableCell>
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
                                 <TableCell align="center">{row.categoryID}</TableCell>
                                 <TableCell align="center">
                                     {/*<Link to={`/edit/product/${row.id}`} className={classes.removeLink}>*/}
                                         <Button size="small" variant="contained" color="primary" onClick={() => handleEdit(row.id)}>Edit</Button>
                                 </TableCell>
                                 <TableCell align="center"> 
                                 <Button  size="small" variant="contained" color="secondary" onClick={()=>handleDelete(row.idProduct)}>Remove</Button>
                                 </TableCell>
                             </TableRow>
                         ))}
                     </TableBody>
                    
         </>
    );

};
export default ProductTable;
