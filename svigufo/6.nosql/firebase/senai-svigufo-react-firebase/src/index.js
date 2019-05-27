import React from 'react';
import ReactDOM from "react-dom";
import { Route, BrowserRouter as Router, Switch} from "react-router-dom";

import EventosIndex from './pages/Eventos/Index';
import EventosCadastrar from './pages/Eventos/Cadastrar';
import EventosEditar from './pages/Eventos/Editar';
import ContaRegistrar from './pages/Conta/Registrar';
import ContaLogin from './pages/Conta/Login';

import * as serviceWorker from './serviceWorker';

const routing = (
    <Router>
      <div>
        <Switch>
          <Route exact path="/" component={EventosIndex} />
          <Route path="/Eventos/Cadastrar" component={EventosCadastrar} />
          <Route path="/Eventos/Editar/:id" component={EventosEditar} />
          <Route path="/Conta/Registrar" component={ContaRegistrar} />
          <Route path="/Conta/Login" component={ContaLogin} />
        </Switch>
      </div>
    </Router>
  );

ReactDOM.render(routing, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
