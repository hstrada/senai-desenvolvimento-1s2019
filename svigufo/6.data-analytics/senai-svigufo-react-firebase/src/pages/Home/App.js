import React, { Component } from "react";
import firebase from "../../services/firebaseConfig";

import "../../assets/css/flexbox.css";
import "../../assets/css/reset.css";
import "../../assets/css/style.css";

import Rodape from "../../components/Rodape/Rodape";
import Cabecalho from "../../components/Cabecalho";

class App extends Component {
  constructor() {
    super();
    this.state = {
      listaEventos: []
    };
  }

  convertDate(inputFormat) {
    function pad(s) { return (s < 10) ? '0' + s : s; }
    var d = new Date(inputFormat);
    return [pad(d.getDate()), pad(d.getMonth()+1), d.getFullYear()].join('/') + " " + d.getTime();
  }

  componentDidMount() {
    let rootRef = firebase.firestore().collection("eventos");
    rootRef.get().then(eventos => {
      let eventosArray = [];
      eventos.forEach(evento => {
        let dataEvento = this.convertDate(new Date(evento.data().data.toDate()));
        console.log('tag', evento.id, "=>", dataEvento)
        eventosArray.push({
          id: evento.id,
          titulo: evento.data().titulo,
          descricao: evento.data().descricao,
          data: ''
        });
      });
      this.setState({ listaEventos: eventosArray });
    });
  }
  render() {
    return (
      <div>
        <Cabecalho />

        <section className="conteudoImagem">
          <div>
            <h1>Svigufo</h1>
            <h2>Área de eventos da Escola SENAI de Informática.</h2>
          </div>
        </section>

        <main className="conteudoPrincipal">
          <section id="conteudoPrincipal-eventos">
            <h1 id="conteudoPrincipal-eventos-titulo">Próximos Eventos</h1>
            <div className="container">
              <nav>
                <ul className="conteudoPrincipal-dados">
                  {this.state.listaEventos.map(evento => {
                    return (
                        <li key={evento.id} className="conteudoPrincipal-dados-link eventos">
                          <h2>{evento.titulo}</h2>
                          <p>{evento.descricao}</p>
                          <p>{evento.data}</p>
                          <button>conectar</button>
                        </li>
                    );
                  })}
                </ul>
              </nav>
            </div>
          </section>

          <section id="conteudoPrincipal-visao">
            <h1 id="conteudoPrincipal-visao-titulo">Por Quê Participar?</h1>
            <div className="container">
              <p className="visao-texto">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. <br />
                Nullam auctor suscipit eros sed blandit. <br />
                Fusce euismod neque sed dapibus sollicitudin. <br />
                Duis vel lacus vestibulum, molestie dui eu, bibendum nunc.
              </p>
            </div>
          </section>

          <section id="conteudoPrincipal-contato">
            <h1 id="conteudoPrincipal-contato-titulo">Contato</h1>
            <div className="container conteudo-contato-titulo">
              <div className="contato-mapa conteudo-contato-mapa" />
              <div className="contato-endereco conteudo-contato-endereco">
                Alameda Barão de Limeira, 539 <br />
                São Paulo - SP
              </div>
            </div>
          </section>
        </main>

        {/* <footer className="rodapePrincipal">
          <section className="rodapePrincipal-patrocinadores">
            <div className="container">
              <p>Escola SENAI de Informática - 2019</p>
            </div>
          </section>
        </footer> */}

        <Rodape />
      </div>
    );
  }
}

export default App;
