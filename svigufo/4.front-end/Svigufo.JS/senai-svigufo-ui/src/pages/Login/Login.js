import React, { Component } from "react";

import "../../assets/css/login.css";

import logo from "../../assets/img/icon-login.png";
import axios from "axios";

class Login extends Component {
  constructor(props){
    super(props);
    this.state = {
      email : "",
      password : ""
    }
  }

  atualizaEstadoEmail(event){
    this.setState({ email : event.target.value});
  }

  atualizaEstadoPassword(event){
    this.setState({ password : event.target.value});
  }

  efetuaLogin(event){
    event.preventDefault();
    
    axios.post('http://192.168.4.112:5000/api/login', {
      "email": this.state.email,
      "senha": this.state.password
    })
    .then(resposta => console.log(resposta))
    .then(data => {
      let token = data.data.token;
      localStorage.setItem('usuario-svigufo', JSON.stringify(token));
      this.props.history.push('/tiposeventos')
    })
  }

  render() {
    return (
      <div>
        <section className="container flex">
          <div className="img__login">
            <div className="img__overlay" />
          </div>

          <div className="item__login">
            <div className="row">
              <div className="item">
                <img src={logo} className="icone__login" />
              </div>
              <div className="item" id="item__title">
                <p className="text__login" id="item__description">
                  Bem-vindo! Faça login para acessar sua conta.
                </p>
              </div>
              <form onSubmit={this.efetuaLogin.bind(this)}>
                <div className="item">
                  <input
                    className="input__login"
                    placeholder="username"
                    type="text"
                    value={this.state.email}
                    onChange={this.atualizaEstadoEmail.bind(this)}
                    name="username"
                    id="login__email"
                  />
                </div>
                <div className="item">
                  <input
                    className="input__login"
                    placeholder="password"
                    type="password"
                    value={this.state.Passwordl}
                    onChange={this.atualizaEstadoPassword.bind(this)}
                    name="password"
                    id="login__password"
                  />
                </div>
                <div className="item">
                  <button type="submit" className="btn btn__login" id="btn__login">
                    Login
                  </button>
                </div>
              </form>
            </div>
          </div>
        </section>
      </div>
    );
  }
}

export default Login;
