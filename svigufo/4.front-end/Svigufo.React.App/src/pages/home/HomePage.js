import React, {Component} from 'react'
import Rodape from '../../components/Rodape'
import DadosEventoCard from '../../components/DadosEventoCard'

import '../../assets/css/flexbox.css'
import '../../assets/css/reset.css'
import '../../assets/css/style.css'

import Logo from '../../assets/img/icon-login.png'

class HomePage extends Component {

    render(){
        return (
            <div>
                <header className="cabecalhoPrincipal">
                <div className="container">
                <img src={Logo} />

                <nav className="cabecalhoPrincipal-nav">
                    <a>Home</a>
                    <a>Eventos</a>
                    <a>Contato</a>
                    <a className="cabecalhoPrincipal-nav-login" href="login.html">Login</a>
                </nav>
                </div>
            </header>

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
                                <DadosEventoCard Titulo="Evento 1" Descricao="Descrição evento 1." />
                                <DadosEventoCard Titulo="Evento 2" Descricao="Descrição evento 2" />
                                <DadosEventoCard Titulo="Evento 3" Descricao="Descrição evento 3" />
                                <DadosEventoCard Titulo="Evento 4" Descricao="Descrição evento 4" />
                            </ul>
                        </nav>
                    </div>
                </section>

                <section id="conteudoPrincipal-visao">
                    <h1 id="conteudoPrincipal-visao-titulo">Por Quê Participar?</h1>
                    <div className="container">
                        <p className="visao-texto">Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                        Nullam auctor suscipit eros sed blandit. 
                        Fusce euismod neque sed dapibus sollicitudin. Duis vel lacus vestibulum,
                        molestie dui eu, bibendum nunc.</p>
                    </div>
                </section>

                <section id="conteudoPrincipal-contato">
                    <h1 id="conteudoPrincipal-contato-titulo">Contato</h1>
                    <div className="container" style={{display: 'flex',justifycontent : 'center',aligncontent: 'center'}}>
                        <div className="contato-mapa" style={{marginright: '70px',backgroundimage: 'linear-gradient(rgba(111, 71, 255, 0.5), rgba(111, 71, 255, 0.3)) url(https://via.placeholder.com/150)',width: '150px',height: '150px'}}>
                        </div>
                        <div className="contato-endereco" style={{fontfamily:'Open Sans', lineheight: '30px',letterspacing: '2px'}}>
                        Alameda Barão de Limeira, 539 
                        São Paulo - SP</div>
                    </div>
                </section>
            </main>
            <Rodape />
            </div>

        )
    }

}

export default HomePage;