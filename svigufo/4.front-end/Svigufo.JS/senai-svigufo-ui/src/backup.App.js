import React, { Component } from "react";
// import logo from './logo.svg';
// import './App.css';
import "./assets/css/flexbox.css";
import "./assets/css/reset.css";
import "./assets/css/style.css";
import logo from "./assets/img/icon-login.png";

class App extends Component {
  
  constructor() {
    super();
    this.state = {
      lista: [],
      nome: ""
    };

    this.enviaFormulario = this.enviaFormulario.bind(this);

    this.setNome = this.setNome.bind(this);
  }

  setNome(evento) {
    this.setState({ nome: evento.target.value });
  }

  componentWillMount() {
    fetch("http://localhost:5000/api/tiposeventos")
      .then(response => response.json())
      .then(data => this.setState({ lista: data }));
  }

  enviaFormulario(evento) {
    evento.preventDefault();
    console.log("Enviando Formulário");

    let objeto = { nome: this.state.nome };

    fetch("http://localhost:5000/api/tiposeventos", {
      method: "post",
      body: JSON.stringify(objeto),
      headers: {
        "Content-Type": "application/json"
      }
    })
      .then(function(response) {
        return response.json();
      })
      .then(function(data) {
        console.log(data);
      });
  }

  render() {
    return (
      <div>
        <header className="cabecalhoPrincipal">
          <div className="container">
            <img src={logo} alt="logo" />

            <nav className="cabecalhoPrincipal-nav">
              Administrador
              <i className="fa fa-cog fa-header" aria-hidden="true" />
            </nav>
          </div>
        </header>

        <main className="conteudoPrincipal">
          <section className="conteudoPrincipal-cadastro">
            <h1 className="conteudoPrincipal-cadastro-titulo">
              Tipos de Eventos
            </h1>

            <div className="container" id="conteudoPrincipal-lista">
              <table id="tabela-lista">
                <thead>
                  <tr>
                    <th>#</th>
                    <th>Título</th>
                    <th>Ação</th>
                  </tr>
                </thead>

                <tbody>
                  {this.state.lista.map(function(tipoEvento) {
                    return (
                      <tr key={tipoEvento.id}>
                        <td>{tipoEvento.id}</td>
                        <td>{tipoEvento.nome}</td>
                      </tr>
                    );
                  })}
                </tbody>
              </table>
            </div>

            <form onSubmit={this.enviaFormulario.bind(this)}>
              <div className="container" id="conteudoPrincipal-cadastro">
                <h2 className="conteudoPrincipal-cadastro-titulo">
                  Cadastrar Tipo de Evento
                </h2>
                <div className="container">
                  <input
                    type="text"
                    id="nome-tipo-evento"
                    placeholder="tipo do evento"
                    value={this.state.nome}
                    onChange={this.setNome}
                  />
                </div>
                <button className="conteudoPrincipal-btn conteudoPrincipal-btn-cadastro">
                  Cadastrar
                </button>
              </div>
            </form>
          </section>
        </main>

        <footer className="rodapePrincipal">
          <section className="rodapePrincipal-patrocinadores">
            <div className="container">
              <p>Escola SENAI de Informática - 2019</p>
            </div>
          </section>
        </footer>
      </div>
    );
  }
}

export default App;
