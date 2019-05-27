import React, { Component } from "react";
import Rodape from "../../components/Rodape/Rodape";
import Header from "../../components/Cabecalho";

import firebase from '../../services/firebaseConfig';

class Cadastro extends Component {
  constructor() {
    super();

    this.state = {
      titulo: "",
      data: "",
      acessoLivre: "",
      tipoEventoId: "",
      instituicaoId: 1,
      descricao: "",
      listaTiposEventos: [],
      listaEventos: []
    };
  }

  componentDidMount() {
    // apiService
    //   .call("tiposeventos")
    //   .getAll()
    //   .then(data => {
    //     this.setState({ listaTiposEventos: data.data });
    //   });

    // apiService
    //   .call("eventos")
    //   .getAll()
    //   .then(data => {
    //     this.setState({ listaEventos: data.data });
    //   });
  }

  atualizaEstado(event) {
    this.setState({ [event.target.name] : event.target.value });
  }

  cadastraEvento(event) {
    event.preventDefault();

    let evento = {
      ativo : true,
      titulo: this.state.titulo,
      data: firebase.firestore.Timestamp.fromDate(new Date(this.state.data + " 19:35:00")),
      acessoLivre: this.state.acessoLivre,
      descricao: this.state.descricao
    };

    let rootRef =  firebase.firestore().collection('eventos');

    rootRef.add(evento)
        .then(function(docRef) {
            console.log("Document written with ID: ", docRef.id);
        })
        .catch(function(error) {
            console.error("Error adding document: ", error);
        });
  }

  render() {
    return (
      <div>
        <Header />
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
                  {this.state.listaEventos.map(element => {
                    return (
                      <tr key={element.id}>
                        <td>{element.id}</td>
                        <td>{element.titulo}</td>
                        <td>{element.data}</td>
                        <td>{element.acessoLivre ? "Sim" : "Não"}</td>
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
              <form onSubmit={this.cadastraEvento.bind(this)} noValidate>
                <div className="container">
                  <input
                    type="text"
                    id="evento__titulo"
                    name = "titulo"
                    value={this.state.titulo}
                    onChange={this.atualizaEstado.bind(this)}
                    placeholder="título do evento" required
                  />
                  <input
                    type="date"
                    id="evento__data"
                    name = "data"
                    onChange={this.atualizaEstado.bind(this)}
                    value={this.state.data}
                    placeholder="dd/MM/yyyy" required
                  />

                  <select
                    id="option__acessolivre"
                    name = "acessoLivre"
                    value={this.state.acessoLivre}
                    onChange={this.atualizaEstado.bind(this)} required
                  >
                    <option>Selecione</option>
                    <option value="1">Livre</option>
                    <option value="0">Restrito</option>
                  </select>

                  {/* <select
                    id="option__tipoevento"
                    value={this.state.tipoEventoId}
                    onChange={this.atualizaEstado.bind(this)} required
                  >
                    <option>Selecione</option>
                    {this.state.listaTiposEventos.map(element => {
                      return (
                        <option key={element.id} value={element.id}>
                          {element.nome}
                        </option>
                      );
                    })}
                  </select> */}
                  <textarea
                    rows="3"
                    cols="50"
                    name = "descricao"
                    placeholder="descrição do evento"
                    value={this.state.descricao}
                    onChange={this.atualizaEstado.bind(this)}
                    id="evento__descricao"  required
                  />
                  <button type="submit" className="conteudoPrincipal-btn conteudoPrincipal-btn-cadastro">
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

export default Cadastro;
