import React, {Component} from 'react'

class DadosEventoCard extends Component {
    constructor(props){
        super();
    }

    render(){
        return (
            <li className="conteudoPrincipal-dados-link eventos">
                <h2>{this.props.Titulo}</h2>
                <p>
                    {this.props.Descricao}
                </p>
                <button >conectar</button>
            </li>
        )
    }
}

export default DadosEventoCard;