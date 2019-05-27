import React, { Component} from 'react'
import firebase from '../../services/firestore';

export default class EventoCadastrar extends Component{
    _isMounted = false;

    constructor(props){
        super(props);
        this.state = {
            titulo : "", descricao : "", data : "", hora : "", ativo : true,  acessoLivre : true,
        }

        this.editarEvento = this.editarEvento.bind(this);
    }

    alteraState(event){
        this.setState({[event.target.name] : event.target.value})
    }

    buscarPorId(){
        //console.log("Id: ",this.props.match.params.id);
        
        firebase.firestore().collection("eventos")
            .doc(this.props.match.params.id)
            .get()
            .then((evento) => {
                let dataHora = new Date(evento.data().data.toDate())
                console.log(dataHora.getMinutes());
                this.setState({
                    titulo : evento.data().titulo,
                    descricao : evento.data().descricao,
                    data : evento.data().data.toDate().toISOString().split('T')[0],
                    hora : evento.data().data.toDate().toTimeString().slice(0,5),
                    ativo : evento.data().ativo,
                    acessoLivre : evento.data().acessoLivre
                })
            }).catch((erro) => {
                console.log(erro);
            });
    }

    componentDidMount(){
        this._isMounted = true;
        this.buscarPorId();
    }

    componentWillUnmount() {
        this._isMounted = false;
      }
    

    editarEvento(event){
        event.preventDefault();
        let datahora = new Date(this.state.data + " " + this.state.hora);

        const evento = {
            id: this.props.match.params.id,
            titulo : this.state.titulo, descricao : this.state.descricao,
            data : firebase.firestore.Timestamp.fromDate(datahora), ativo :this.state.ativo,
            acessoLivre : this.state.acessoLivre,
        }

        firebase.firestore().collection("eventos")
            .doc(this.props.match.params.id)
            .set(evento)
            .then((result) => {
                alert('Evento Alterado')

                this.props.history.push('/')
            });
    }

    render(){
        return (
            <div>
                <h3>Eventos Cadastrar</h3>
                <form onSubmit={this.editarEvento}>
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
                </form>
            </div>
        )
    }
}