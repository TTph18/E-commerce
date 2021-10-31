import React, { Component, useEffect } from "react";
import { Link } from "react-router-dom";
import { UserContext } from "../../index";
import "./Navbar.css";
import AuthService from "../../services/auth-service";
import { USER_PROFILE_STORAGE_KEY } from "../../Constants/oidc-config";

export default class Navbar extends Component {
  state = {
    username: undefined,
  };

  handleLogin = (e) => {
    AuthService.loginAsync();
  }

  handleLogout = (e) => {
    AuthService.logoutAsync();
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
              <Link to="/contact">
                <li>Contact</li>
              </Link>
              <Link to="/about">
                <li>About</li>
              </Link>
              <Link to="/brand">
                <li>Brand</li>
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
