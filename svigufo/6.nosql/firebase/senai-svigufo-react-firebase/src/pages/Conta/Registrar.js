import React, { Component } from 'react'
import firebase from '../../services/firestore.js'

class ContaRegistrar extends Component {

    constructor(props){
        super(props);
        this.state ={
            nome : '',
            email : '',
            senha : '',
            mensagemErro : ''
        }
    }

    atualizaEstado(event){
        this.setState({ [event.target.name] : event.target.value});    
    }

    cadastrarUsuario(event){
        event.preventDefault();

        firebase.auth().createUserWithEmailAndPassword(this.state.email, this.state.senha)
            .then((usuario) => {
                usuario.user.updateProfile({
                    displayName: this.state.nome,
                    role : 'Administrador'
                }).then(function() {
                    alert('Usuario Cadastrado')
                }, function(error) {
                        // An error happened.
                });
            })
            .catch(function(error) {
                console.log('tag erro', error)
            });
    }

    render(){
        return (
            <div>
                <h2>Conta Registrar</h2>
                <form onSubmit={this.cadastrarUsuario.bind(this)}>
                    <label>Nome</label>
                    <input type="text" required name="nome" value={this.state.nome}  onChange={this.atualizaEstado.bind(this)} />

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

export default ContaRegistrar;