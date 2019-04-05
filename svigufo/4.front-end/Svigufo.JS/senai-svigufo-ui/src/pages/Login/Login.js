import React, { Component } from "react";

import "../../assets/css/login.css";

import logo from "../../assets/img/icon-login.png";
import axios from "axios";

import jwt from "../../utils/jwt";

class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
          email: "",
          password: "",
          erro: ""
        };
      }

      atualizaEstadoEmail(event) {
        this.setState({ email: event.target.value });
      }
    
      atualizaEstadoPassword(event) {
        this.setState({ password: event.target.value });
      }

      efetuaLogin(event) {
        event.preventDefault();
    
        axios.post("http://192.168.4.112:5000/api/login", {
            email: this.state.email,
            senha: this.state.password
          })
          .then(data => {
            if (data.status === 200) {
              console.log(data.data.token);
              localStorage.setItem("usuario-svigufo", data.data.token);
              this.props.history.push("/tiposeventos");
              console.log(jwt(localStorage.getItem("usuario-svigufo")));
            } else {
              this.setState({ erro: 'Usuário ou senha inválidos.' })
              console.log("erro");
            }
          })
          .catch(erro => {
            this.setState({ erro: 'Usuário ou senha inválidos.' })
          });
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
                    <img src={logo} className="icone__login" alt="" />
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
                        value={this.state.password}
                        onChange={this.atualizaEstadoPassword.bind(this)}
                        name="password"
                        id="login__password"
                      />
                    </div>
                    <p className="text__login" style={{ color: 'red', textAlign: 'center' }}>{this.state.erro}</p>
                    <div className="item">
                      <button
                        type="submit"
                        className="btn btn__login"
                        id="btn__login"
                      >
                        Login
                      </button>
                    </div>
                  </form>
                </div>
              </div>
            </section>
          </div>
      )};
}

export default Login;
