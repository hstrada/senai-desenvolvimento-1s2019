import React, { Component } from "react";

import "../../assets/css/flexbox.css";
import "../../assets/css/reset.css";
import "../../assets/css/style.css";

import Rodape from "../../components/Rodape/Rodape";
import Cabecalho from "../../components/Cabecalho/Cabecalho";

class Eventos extends Component {
  constructor() {
    super();
    this.state = {
      lista: [],
      tiposEventos: [],
      tipoEventoId: ""
    };

    this.setTipoEventoId = this.setTipoEventoId.bind(this);
  }

  buscarEventos() {
    fetch("http://localhost:5000/api/eventos")
      .then(response => response.json())
      .then(data => this.setState({ lista: data }));
  }

  componentDidMount() {
    this.buscarEventos();
    this.buscarTiposEventos();
  }

  buscarTiposEventos() {
    fetch("http://localhost:5000/api/tiposeventos")
      .then(response => response.json())
      .then(data => this.setState({ tiposEventos: data }));
  }

  setTipoEventoId(event) {
    console.log(event.target.value);
    this.setState({ tipoEventoId: event.target.value });
  }

  render() {
    return (
      <div>
        <Cabecalho />

        <main className="conteudoPrincipal">
          <section className="conteudoPrincipal-cadastro">
            <h1 className="conteudoPrincipal-cadastro-titulo">Eventos</h1>
            <div className="container" id="conteudoPrincipal-lista">
              <table id="tabela-lista">
                <thead>
                  <tr>
                    <th>#</th>
                    <th>Evento</th>
                    <th>Data</th>
                    <th>Acesso Livre</th>
                    <th>Tipo do Evento</th>
                  </tr>
                </thead>

                <tbody>
                  {this.state.lista.map(function(evento) {
                    return (
                      <tr key={evento.id}>
                        <td>{evento.id}</td>
                        <td>{evento.titulo}</td>
                        <td>{evento.dataEvento}</td>
                        {evento.acessoLivre == true ? (
                          <td>Sim</td>
                        ) : (
                          <td>Não</td>
                        )}
                        <td>{evento.tipoEvento.nome}</td>
                      </tr>
                    );
                  })}
                </tbody>
              </table>
            </div>

            <div className="container" id="conteudoPrincipal-cadastro">
              <h2 className="conteudoPrincipal-cadastro-titulo">
                Cadastrar Evento
              </h2>
              <div className="container">
                <input
                  type="text"
                  id="evento__titulo"
                  placeholder="título do evento"
                />
                <input type="text" id="evento__data" placeholder="dd/MM/yyyy" />
                <select id="option__acessolivre">
                  <option value="1">Livre</option>
                  <option value="0">Restrito</option>
                </select>
                <select
                  value={this.state.tipoEventoId}
                  name="tipoEventoId"
                  id="tipoEventoId"
                  onChange={this.setTipoEventoId}
                >
                  <option value="">Selecione o Tipo de Evento</option>
                  {this.state.tiposEventos.map(function(tipoEvento) {
                    return (
                      <option value={tipoEvento.id} key={tipoEvento.id}>
                        {tipoEvento.nome}
                      </option>
                    );
                  })}
                </select>
                <select id="option__tipoevento">
                  <option value="0" disabled>
                    Tipo do Evento
                  </option>
                </select>
                <textarea
                  rows="3"
                  cols="50"
                  placeholder="descrição do evento"
                  id="evento__descricao"
                />
              </div>
              <button className="conteudoPrincipal-btn conteudoPrincipal-btn-cadastro">
                Cadastrar
              </button>
            </div>
          </section>
        </main>

        <Rodape />
      </div>
    );
  }
}

export default Eventos;
