import React, { useState, useEffect } from 'react';
import { useHistory } from "react-router";
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
import {
    EDIT_CATEGORY_ID
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

const CategoryTable = ({
  categories,
  fetchData,
}) => {
    const classes = useStyles();
    const history = useHistory();
    
    const handleEdit = (id) => {
        const existCategory =categories.find(item => item.id === Number(id));
        history.push(
            EDIT_CATEGORY_ID(id),
          {
            existCategory: existCategory
          }
        );
      };

     return (
         <>
             <TableContainer component={Paper}>
                 <Table className={classes.table} aria-label="simple table">
                     <TableHead>
                         <TableRow>
                             <TableCell>Name</TableCell>
                         </TableRow>
                     </TableHead>
                     <TableBody>
                         {categories && categories.map((row) => (
                             <TableRow key={row.id}>
                                 <TableCell component="th" scope="row">{row.name}</TableCell>
                                 <TableCell align="center">
                                     {/*<Link to={`/edit/product/${row.id}`} className={classes.removeLink}>*/}
                                         <Button size="small" variant="contained" color="primary" onClick={() => handleEdit(row.id)}>Edit</Button>
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
export default CategoryTable;
