import React from "react";
import { get, del, post } from "../../httpHelper";
import { Link } from "react-router-dom";
import "./Contact.css";

export default class Contact extends React.Component {
  state = {
    userList: [],
  };

  componentDidMount() {
    this.fetchUserList();
  }

  fetchUserList() {
    get("/api/User/get-all-users").then((response) => {
      if (response.status === 200) {
        const arr = Object.values(response.data);
        this.setState({ userList: arr[1] });
      }
    });
  }

  handleDeleteUser(userId) {
    // delete user
    del(`/user/${userId}`).then((response) => {
      console.log(response);
      // if success
      // this.setState({});
      // this.fetchUserList(); // refresh user list
    });
  }

  handeAddNewUser() {
    post(`/users`, {
      name: "Tuan",
      email: "tuan@nomail.com",
    }).then((response) => {
      console.log(response.data);
      // this.fetchUserList(); // refresh user list
      this.setState({
        userList: [...this.state.userList, response.data],
      });
    });
  }

  render() {
    return (
      <div>
        <table id="table">
          <thead>
            <tr>
              <th>Id</th>
              <th>Name</th>
              <th>Email</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {this.state.userList.map((user) => (
              <tr key={user.id}>
                <td>{user.id}</td>
                <td>{user.userName}</td>
                <td>{user.email}</td>
                <td>
                  <a>Delete</a>
                  <Link to={`/contacts/${user.id}`}>Edit</Link>
                </td>
              </tr>
            ))}
          </tbody>
        </table>

        <button onClick={() => this.handeAddNewUser()}>Add new user</button>
      </div>
    );
  }
}
