import React, { Component } from 'react';

import logo from '../../assets/img/icon-login.png';
import FormLogin from '../../components/login/FormLogin';

import '../../assets/css/login.css';

class loginPage extends Component {
    constructor(){
        super();
    }
    render(){
        return(
            <section className="container flex">
                <div className="img__login"><div className="img__overlay"></div></div>

                <div className="item__login">
                    <div className="row">
                        <div className="item">
                            <img src={logo} className="icone__login" />
                        </div>
                        <div className="item" id="item__title">
                            <p className="text__login" id="item__description">
                            Bem-vindo! Faça login para acessar sua conta.
                            </p>
                        </div>
                        <FormLogin />
                    </div>
                </div>
            </section>
        )
    }
}

export default loginPage;