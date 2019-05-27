import React, { Component } from "react";
import Cabecalho from "../../components/Cabecalho";
import Rodape from "../../components/Rodape/Rodape";
import Titulo from "../../components/Titulo";
import firebase from '../../services/firebaseConfig';

class Index extends Component {
  constructor() {
    super();

    this.state = {
      listaEventos: []
    };
  }

  listaEventos(){
    let rootRef =  firebase.firestore().collection('eventos');
    
    //utilizar where
    rootRef.where("ativo", "==", true).get().then((eventos) => {
        let eventosArray = []
        eventos.forEach((evento) => {
            console.log(evento.id, "=>", evento.data());
            eventosArray.push({
                id : evento.id,
                titulo : evento.data().titulo,
                descricao : evento.data().descricao,
                data : evento.data().data
            })
        })
        this.setState({ listaEventos : eventosArray})
    })
  }

  realTimeListaEventos(){
    let rootRef =  firebase.firestore().collection('eventos');
    let root = this;
    rootRef.onSnapshot(() => {
        root.listaEventos();
    }, function(error) {
        console.log(error);
    });
  }

  componentDidMount() {
    this.listaEventos();
    this.realTimeListaEventos();
  }

  render() {
    return (
      <div>
        <Cabecalho />

        <main className="conteudoPrincipal">
          <div className="container">
            <Titulo mensagem="Lista de Eventos" />

            <nav>
              <ul className="conteudoPrincipal-dados" id="ul-dados">
                {this.state.listaEventos.map((element) => {
                  return (
                    <li key={element.id} className="conteudoPrincipal-dados-link">
                      <h2 className="conteudoPrincipal-dados-titulo titulo-azul">
                        {element.titulo}
                      </h2>
                      <span className="conteudoPrincipal-icone-span">
                        {element.descricao}
                      </span>
                      <span className="conteudoPrincipal-icone-span">
                        {element.data.seconds}
                      </span>
                      <p>{}</p>
                      {/* <p classNameName="titulo-tipo-evento"><small>{element.tipoEvento.nome}</small></p> */}
                    </li>
                  );
                })}
              </ul>
            </nav>
          </div>
        </main>

        <Rodape />
      </div>
    );
  }
}

export default Index;
