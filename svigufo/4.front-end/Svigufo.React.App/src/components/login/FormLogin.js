import React from 'react';

class formLogin extends React.Component {
    constructor(){
        super();
    }

    validaLogin(event){
        //Arrumar refresh na página
        event.preventDefault();
        var email = document.getElementById('email').value;
        var senha = document.getElementById('senha').value;

        if(email == 'senai@senai.com' && senha == '132'){
            alert('Usuário Logado');
        }else{
            alert('Acesso negado');
        }
    }  

    render() {
        return (
            <form>
            <div  onSubmit={this.validaLogin}  className="item">
              <input
                className="input__login"
                placeholder="username"
                type="text"
                name="username"
                id="login__email"
              />
            </div>
            <div className="item">
              <input
                className="input__login"
                placeholder="password"
                type="password"
                name="password"
                id="login__password"
              />
            </div>
            <div className="item">
              <button type="submit" className="btn btn__login" id="btn__login">
                Login
              </button>
            </div>
          </form>
        );
    }
}   

export default formLogin;