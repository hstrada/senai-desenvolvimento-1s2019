import React from "react";
import ReactDOM from "react-dom";
import { Route, BrowserRouter as Router, Switch, Redirect } from "react-router-dom";
import "./index.css";
import App from "./pages/Home/App";

import TiposEventos from "./pages/TiposEventos/TiposEventos";
import NaoEncontrada from "./pages/NaoEncontrada/NaoEncontrada";
import Login from './pages/Login/Login';
import * as serviceWorker from "./serviceWorker";

import { usuarioAutenticado } from "./services/auth";

const PermissaoAdmin = ({ component: Component, ...rest }) => (
  <Route
    {...rest}
    render={props => usuarioAutenticado() ? (
        <Component {...props} />
      ) : (
        <Redirect
          to={{ pathname: "/login", state: { from: props.location } }}
        />
      )
    }
  />
);

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={App} />
        <PermissaoAdmin path="/tiposeventos" component={TiposEventos} />
        <Route path="/login" component={Login} />
        <Route component={NaoEncontrada} />
      </Switch>
    </div>
  </Router>
);

ReactDOM.render(routing, document.getElementById("root"));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
