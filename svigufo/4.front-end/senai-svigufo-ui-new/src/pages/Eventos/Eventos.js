import React, { Component } from "react";
import Rodape from "../../components/Rodape/Rodape";
import Titulo from "../../components/Titulo";
import axios from "axios";

import logo from "../../assets/img/icon-login.png";

import "../../assets/css/flexbox.css";
import "../../assets/css/reset.css";
import "../../assets/css/style.css";

class Eventos extends Component {
  constructor() {
    super();
    this.state = {
      titulo: "",
      dataEvento: "",
      acessoLivre: 0,
      instituicaoId: 0,
      tipoEventoId: 0,
      descricao: "",
      listaTiposEventos : [],
      listaEventos : []
    };
  }


  buscaTiposEventos(){
    axios.get("http://localhost:5000/api/tiposeventos")
    .then(data => {
        this.setState({ listaTiposEventos : data.data});
    })
    .catch(erro => {
        console.log(erro);
    });
  }

  buscaEventos(){
    axios.get("http://localhost:5000/api/eventos")
    .then(data => {
        console.log(data);
        this.setState({ listaEventos : data.data});
    })
    .catch(erro => {
        console.log(erro);
    });
  }

  componentDidMount(){
      this.buscaTiposEventos();
      this.buscaEventos();
  }

  atualizaEstadoTitulo(event) {
    this.setState({ titulo: event.target.value });
  }

  atualizaEstadoDataEvento(event) {
    this.setState({ dataEvento: event.target.value });
  }

  atualizaEstadoAcessoLivre(event) {
    this.setState({ acessoLivre: event.target.value });
  }

  atualizaEstadoInstituicaoId(event) {
    this.setState({ instituicaoId: event.target.value });
  }

  atualizaEstadoTipoEventoId(event) {
    this.setState({ tipoEventoId: event.target.value });
  }

  atualizaEstadoDescricao(event) {
    this.setState({ descricao: event.target.value });
  }

  cadastraEvento(event) {
    event.preventDefault();

    let evento = {
      titulo: this.state.titulo,
      dataEvento: this.state.dataEvento,
      acessoLivre: parseInt(this.state.acessoLivre),
      instituicaoId: this.state.instituicaoId,
      tipoEventoId: this.state.tipoEventoId,
      descricao: this.state.descricao
    };

    axios.post("http://localhost:5000/api/eventos", evento)
        .then(data => {
            console.log(data);
            this.buscaEventos();
        })
        .catch(erro => {
            console.log(erro);
        });
  }

  render() {
    return (
      <div>
        <header className="cabecalhoPrincipal">
          <div className="container">
            <img src={logo} />
            <nav className="cabecalhoPrincipal-nav">Administrador</nav>
          </div>
        </header>
        <main className="conteudoPrincipal">
          <section className="conteudoPrincipal-cadastro">
            <Titulo mensagem="Eventos" />>
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
                    {
                        this.state.listaEventos.map((element) =>{
                            return (
                                <tr key={element.id}>
                                    <td>{element.id}</td>
                                    <td>{element.titulo}</td>
                                    <td>{element.dataEvento}</td>
                                    <td>{element.acessoLivre ? 'Sim' : 'Não'}</td>
                                    <td>{element.tipoEvento.nome}</td>
                                </tr>
                            );
                        })
                    }
                </tbody>
              </table>
            </div>
            <div className="container" id="conteudoPrincipal-cadastro">
              <Titulo mensagem="Cadastrar Eventos" />>
              <div className="container">
                <form>
                  <div className="container">
                    <input
                      type="text"
                      id="evento__titulo"
                      placeholder="título do evento"
                      value={this.state.titulo}
                      onChange={this.atualizaEstadoTitulo.bind(this)}
                      required
                    />
                    <input
                      type="date"
                      id="evento__data"
                      placeholder="dd/MM/yyyy"
                      value={this.state.dataEvento}
                      onChange={this.atualizaEstadoDataEvento.bind(this)}
                      required
                    />
                    <select
                      id="option__acessolivre"
                      value={this.state.acessoLivre}
                      onChange={this.atualizaEstadoAcessoLivre.bind(this)}
                      required
                    >
                      <option value="0">Selecione</option>
                      <option value="1">Livre</option>
                      <option value="0">Restrito</option>
                    </select>
                    <select
                      id="option__instituicao"
                      value={this.state.instituicaoId}
                      onChange={this.atualizaEstadoInstituicaoId.bind(this)}
                      required
                    >
                      <option value="0">Selecione</option>
                      <option value="2">Senai</option>
                    </select>
                    <select
                      id="option__tipoevento"
                      value={this.state.tipoEventoId}
                      onChange={this.atualizaEstadoTipoEventoId.bind(this)}
                      required
                    >
                      <option value="0">Selecione</option>
                      {
                          this.state.listaTiposEventos.map((element) => {
                              return <option value={element.id} key={element.id}>{element.nome}</option>
                          })
                      }
                    </select>
                    <textarea
                      rows="3"
                      cols="50"
                      placeholder="descrição do evento"
                      id="evento__descricao"
                      value={this.state.descricao}
                      onChange={this.atualizaEstadoDescricao.bind(this)}
                    />
                  </div>
                </form>
              </div>
              <button
                onClick={this.cadastraEvento.bind(this)}
                className="conteudoPrincipal-btn conteudoPrincipal-btn-cadastro"
              >
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
