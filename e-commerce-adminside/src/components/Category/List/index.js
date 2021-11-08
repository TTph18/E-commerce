import React, { useState, useEffect, Suspense } from 'react';
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
import Url from '../../../services/url';
import CategoryTable from "./CategoryTable";

import { getCategoryRequest } from "../services/request"

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

const ListCategory = () => {
    const classes = useStyles();

    const [categories, setCategories] = useState("");

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
      }, [categories])
    
      const fetchDataCallbackAsync = async () =>  {
        let data = await getCategoryRequest();
        console.log('fetchDataCallbackAsync');
        console.log(data);
      }
      
    return (
      <>
        <div className="d-flex align-items-center ml-3">
          <Link to="/category/create" type="button" className="btn btn-danger">
            Create new category
            </Link>
          <Suspense fallback={<div>Loading..</div>}>
            <CategoryTable
              categories={categories}
              fetchData={fetchDataCallbackAsync}
            />
          </Suspense>
        </div>
      </>
    );
};
 
export default ListCategory;
