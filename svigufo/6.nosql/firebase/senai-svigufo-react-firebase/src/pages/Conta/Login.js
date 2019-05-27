import React, { Component } from "react";
import firebase from '../../services/firestore.js'

class ContaLogin extends Component {

    constructor(props){
        super(props);
        this.state ={
            email : '',
            senha : '',
            mensagemErro : ''
        }
    }

    atualizaEstado(event){
        this.setState({ [event.target.name] : event.target.value});    
    }

    logar(event){
        event.preventDefault();

        firebase.auth().signInWithEmailAndPassword(this.state.email, this.state.senha)
            .then((usuario) => {
                alert("Login Efetuado");
                console.log('tag', usuario);
            })
            .catch(function(error) {
                console.log('tag erro', error)
            });
    }

    render(){
        return (
            <div>
                <h2>Conta Registrar</h2>
                <form onSubmit={this.logar.bind(this)}>
                    <label>Email</label>
                    <input type="text" required name="email" value={this.state.email}  onChange={this.atualizaEstado.bind(this)} />

                    <label>Senha</label>
                    <input type="password" required name="senha" value={this.state.senha}   onChange={this.atualizaEstado.bind(this)} />

                    <p>{ this.state.mensagemErro }</p>
                    <button type="submit">Enviar</button>
                </form>
            </div>
        )
    }

}

export default ContaLogin;