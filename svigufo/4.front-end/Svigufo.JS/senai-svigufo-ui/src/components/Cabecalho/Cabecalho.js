import React from "react";

import logo from "../../assets/img/icon-login.png";

function Cabecalho() {
  return (
    <header className="cabecalhoPrincipal">
      <div className="container">
        <img src={logo} alt="Svigufo - ícone de login" />

        <nav className="cabecalhoPrincipal-nav">Administrador</nav>
      </div>
    </header>
  );
}

export default Cabecalho;
