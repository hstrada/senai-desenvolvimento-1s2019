import React, { Component } from "react";

import logo from "../../assets/img/icon-login.png";

import "../../assets/css/flexbox.css";
import "../../assets/css/reset.css";
import "../../assets/css/style.css";

import Rodape from "../../components/Rodape/Rodape";

class TiposEventos extends Component {
  constructor() {
    super();
    this.state = { lista: []
    //   lista: [
    //     {
    //       id: 7,
    //       nome: "Desenvolvimento de Sistemas"
    //     },
    //     {
    //       id: 2,
    //       nome: "DESIGN"
    //     },
    //     {
    //       id: 4,
    //       nome: "LINKEDIN"
    //     },
    //     {
    //       id: 3,
    //       nome: "MARKETING"
    //     },
    //     {
    //       id: 1,
    //       nome: "TECNOLOGIA"
    //     }
    //   ]
    };
  }

  cadastrarTipoEvento(evento) {
    evento.preventDefault();
    console.log('Enviando formulário');
  }

  buscarTiposEventos() {
    fetch("http://localhost:5000/api/tiposeventos")
    .then(response => response.json())
    .then(data => this.setState({ lista: data }));
  }

  componentDidMount() {
      this.buscarTiposEventos();
  }

  render() {
    return (
      <div>
        <header className="cabecalhoPrincipal">
          <div className="container">
            <img src={logo} alt="Svigufo - ícone de login" />

            <nav className="cabecalhoPrincipal-nav">Administrador</nav>
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

            <div className="container" id="conteudoPrincipal-cadastro">
              <h2 className="conteudoPrincipal-cadastro-titulo">
                Cadastrar Tipo de Evento
              </h2>
              <form onSubmit={this.cadastrarTipoEvento}>
                <div className="container">
                  <input
                    type="text"
                    id="nome-tipo-evento"
                    placeholder="tipo do evento"
                  />
                  <button className="conteudoPrincipal-btn conteudoPrincipal-btn-cadastro">
                    Cadastrar
                  </button>
                </div>
              </form>
            </div>
          </section>
        </main>

        <Rodape />
      </div>
    );
  }
}

export default TiposEventos;
