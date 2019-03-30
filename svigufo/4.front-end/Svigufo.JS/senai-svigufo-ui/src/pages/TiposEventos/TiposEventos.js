import React, { Component } from "react";

// import logo from "../../assets/img/icon-login.png";

import "../../assets/css/flexbox.css";
import "../../assets/css/reset.css";
import "../../assets/css/style.css";

import Rodape from "../../components/Rodape/Rodape";
import Cabecalho from "../../components/Cabecalho/Cabecalho";

class TiposEventos extends Component {
  constructor() {
    super();
    this.state = {
      lista: [],
      nome: ""

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

    this.atualizadoEstadoNome = this.atualizadoEstadoNome.bind(this);
    this.cadastrarTipoEvento = this.cadastrarTipoEvento.bind(this);
  }

  //   handleSubmit
  cadastrarTipoEvento(evento) {
    evento.preventDefault();

    fetch("http://localhost:5000/api/tiposeventos", {
      method: "POST",
      // tem como melhorar essa parte?
      body: JSON.stringify({ nome: this.state.nome }),
      headers: {
        "Content-Type": "application/json"
      }
    })
      .then(response => response)
      // como fazer ele dar um refresh?
      .then(this.buscarTiposEventos())
      .catch(error => console.log(error));
  }

  atualizadoEstadoNome(event) {
    this.setState({ nome: event.target.value });
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
        <Cabecalho />

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
                    value={this.state.nome}
                    onChange={this.atualizadoEstadoNome}
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
