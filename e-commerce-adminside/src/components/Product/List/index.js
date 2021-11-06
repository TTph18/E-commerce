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
import {
    ACCSENDING,
    DECSENDING,
    DEFAULT_PAGE_LIMIT,
} from '../../../constants/paging';
import ProductTable from "./ProductTable";

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

    const [products, setProducts] = useState("");

    const [query, setQuery] = useState({
        page: 1,
        limit: DEFAULT_PAGE_LIMIT,
        sortOrder: DECSENDING,
    });

    useEffect(() => {
        async function fetchDataAsync() {
          let result = await getProductRequest(query);
          setProducts(result.data);
        }
    
        fetchDataAsync();
      }, [query, products]);
    
      const fetchDataCallbackAsync = async () =>  {
        let data = await getProductRequest(query);
        console.log('fetchDataCallbackAsync');
        console.log(data);
      }

      const handlePage = (page) => {
        setQuery({
        ...query,
        page,
    });
  };
  const handleSort = (sortColumn) => {
    const sortOrder = query.sortOrder === ACCSENDING ? DECSENDING : ACCSENDING;

    setQuery({
      ...query,
      sortColumn,
      sortOrder,
    });
  };
    return (
      <>
        <div className="d-flex align-items-center ml-3">
          <Link to="/brand/create" type="button" className="btn btn-danger">
            Create new Brand
            </Link>
          <Suspense fallback={<div>Loading..</div>}>
            <ProductTable
              products={products}
              handlePage={handlePage}
              handleSort={handleSort}
              sortState={{
                columnValue: query.sortColumn,
                orderBy: query.sortOrder,
              }}
              fetchData={fetchDataCallbackAsync}
            />
          </Suspense>
        </div>
      </>
    );
};

export default ListProduct;
