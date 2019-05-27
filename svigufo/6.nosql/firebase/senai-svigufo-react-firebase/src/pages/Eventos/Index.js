/* eslint-disable no-useless-constructor */
import React, {Component} from 'react'
import firebase from '../../services/firestore';
import { Link } from 'react-router-dom';

export default class EventosIndex extends Component {

    constructor(props){
        super(props);
        this.state ={
            listaEventos : []
        }
    }

    listarEventosRealTime(){
        let dataAtual = firebase.firestore.Timestamp.fromDate(new Date());

        firebase.firestore().collection("eventos")
            .where("data",">", dataAtual) //Busca datas a partir da data atual
            .where("ativo", "==", true) //Busca eventos ativos
            .onSnapshot((eventos) => {
                let eventosArray = [];
                eventos.forEach((evento) => {
                    eventosArray.push({
                        id : evento.id,
                        titulo : evento.data().titulo,
                        descricao : evento.data().descricao,
                        ativo : evento.data().ativo,
                        data : evento.data().data.toDate().toLocaleString('pt-br')
                    })
                })
                console.log(eventosArray);
                this.setState({ listaEventos : eventosArray});
            });
    }

    // listarEventos(){
    //     //Data Atual
    //     let dataAtual = firebase.firestore.Timestamp.fromDate(new Date());
    //     firebase.firestore().collection("eventos")
    //         .where("data",">", dataAtual) //Busca datas a partir da data atual
    //         .where("ativo", "==", true) //Busca eventos ativos
    //         .get()
    //         .then((eventos) => {
    //             let eventosArray = [];
    //             eventos.forEach((evento) => {
    //                 eventosArray.push({
    //                     id : evento.id,
    //                     titulo : evento.data().titulo,
    //                     descricao : evento.data().descricao,
    //                     ativo : evento.data().ativo,
    //                     data : evento.data().data.toDate().toLocaleString('pt-br')
    //                 })
    //             })
    //             console.log(eventosArray);
    //             this.setState({ listaEventos : eventosArray});
    //         })
    // }
    

    componentDidMount(){
        //this.listarEventos();
        this.listarEventosRealTime();
    }

    excluirEvento(id){
        firebase.firestore().collection("eventos")
            .doc(id)
            .delete()
            .then(function() {
                alert("Evento Excluído");
            }).catch(function(error) {
                console.error("Error removing document: ", error);
            });       
    }

    render(){
        return(
            <div>
                <Link to="/Eventos/Cadastrar">Novo Evento</Link>
                <ul>
                {
                    
                  this.state.listaEventos.map((evento) => {
                      return (
                          <li key={evento.id}>
                              {evento.id} - 
                              {evento.titulo} - 
                              {evento.descricao} - 
                              {evento.data} - 
                              <Link to={"/Eventos/Editar/" + evento.id} >Editar</Link> - 
                              <button type="button" onClick={ this.excluirEvento.bind(this,evento.id)}>Excluir</button>
                          </li>
                      )
                  })  
                }
                </ul>
            </div>
        )
    }
}