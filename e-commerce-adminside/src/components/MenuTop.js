import React, { Component, useEffect } from "react";
import { Link } from "react-router-dom";
import { UserContext } from "../index";
import "./MenuTop.css";
import AuthService from "../services/auth-service";
import { USER_PROFILE_STORAGE_KEY } from "../constants/oidc-config";

export default class MenuTop extends Component {
  state = {
    username: undefined,
  };

  handleLogin = (e) => {
    AuthService.loginAsync();
  }

  handleLogout = (e) => {
    AuthService.logoutAsync();
    this.setState({
        username: undefined
      })
  }

  componentDidMount() {
    let userStorageValue = localStorage.getItem(USER_PROFILE_STORAGE_KEY);
    let user = JSON.parse( userStorageValue );
    if (user !== undefined)
    {
      this.setState({
        username: user?.name
      })
    }

  }

  render() {
    return (
      <UserContext.Consumer>
        {(value) => (
          <nav id="navbar">
            <ul>
              <Link to="/">
                <li>Home</li>
              </Link>
              <Link to="/product">
                <li>Product</li>
              </Link>
              <Link to="/category">
                <li>Category</li>
              </Link>
              <Link to="/contact">
                <li>Contact</li>
              </Link>
            </ul>

            <input type="text" onChange={(e) => this.props.onSearchKey(e)} />

            <div className="nav-details">
              <p className="nav-username"> {this.state.username} </p>
            </div>

            {(this.state.username === undefined) ? (
              <button
                className="btn btn-danger"
                type="button"
                onClick={(e) => this.handleLogin(e)}>
                Login
              </button>
            ): (
              <button
                className="btn btn-danger"
                type="button"
                onClick={(e) => this.handleLogout(e)}>
                Logout
              </button>
            )}

          </nav>
        )}
      </UserContext.Consumer>
    );
  }
}
