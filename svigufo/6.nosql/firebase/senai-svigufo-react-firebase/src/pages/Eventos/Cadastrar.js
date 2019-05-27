import React, { Component} from 'react'
import firebase from '../../services/firestore';
import { Link } from 'react-router-dom';

export default class EventoCadastrar extends Component{

    constructor(props){
        super(props);
        this.state = {
            titulo : "", descricao : "", data : "", hora : "", ativo : false,  acessoLivre : false,
        }

        this.cadastrarEvento = this.cadastrarEvento.bind(this);
    }

    alteraState(event){
        this.setState({[event.target.name] : event.target.value})
    }

    cadastrarEvento(event){
        event.preventDefault();
        let datahora = new Date(this.state.data + " " + this.state.hora);

        const evento = {
            titulo : this.state.titulo, 
            descricao : this.state.descricao,
            data : firebase.firestore.Timestamp.fromDate(datahora), 
            ativo : Boolean(this.state.ativo),
            acessoLivre : Boolean(this.state.acessoLivre),
        }

        firebase.firestore().collection("eventos").add(evento).then((result) => {
                alert('Evento Cadastrado')

                this.props.history.push('/')
            })

        ;
    }

    render(){
        return (
            <div>
                <h3>Eventos Cadastrar</h3>
                <form onSubmit={this.cadastrarEvento}>
                    <div>
                        <label>Titulo</label>
                        <input type="text" name="titulo" value={this.state.titulo} onChange={ this.alteraState.bind(this) } required />
                    </div>

                    <div>
                        <label>Descrição</label>
                        <textarea  name="descricao" value={this.state.descricao} onChange={ this.alteraState.bind(this) } rows="5" required />
                    </div>

                    <div>
                        <input type="checkbox" name="acessoLivre" value={this.state.acessoLivre} defaultChecked={this.state.acessoLivre} onChange={ this.alteraState.bind(this) }  />
                        <label >Acesso Livre</label>
                    </div>

                    <div>
                        <input type="checkbox" name="ativo" value={this.state.ativo}  defaultChecked={this.state.ativo}   onChange={this.alteraState.bind(this)} />
                        <label>Ativo</label>
                    </div>

                    <div>
                        <label>Data</label>
                        <input type="date" name="data" value={this.state.data} onChange={ this.alteraState.bind(this) } />

                        <label>Data</label>
                        <input type="time"  name="hora" value={this.state.hora} onChange={ this.alteraState.bind(this) } />
                    </div>
                    <button type="submit">Enviar</button>
                    <hr/>
                    <Link to="/">voltar</Link>
                </form>
            </div>
        )
    }
}