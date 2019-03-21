var express = require("express");
var app = express();
const PORT = process.env.PORT || 5000;

app.use("/", express.static("apidoc"));

// habilitar o cors - liberar origem
app.use(function(req, res, next) {
  res.setHeader("Access-Control-Allow-Origin", "*");
  res.setHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
  res.setHeader(
    "Access-Control-Allow-Headers",
    "Origin, X-Requested-With, Content-Type, Accept, x-access-token"
  );
  res.setHeader("Access-Control-Allow-Credentials", true);

  next();
});

let personagens = [
  {
    nome: "Homem-Aranha",
    lancamento: "Amazing Fantasy #15 (1962)",
    urlImagem:
      "http://supercinemaup.com/wp-content/uploads/2017/05/homem-aranha.jpg"
  },
  {
    nome: "O Incrível Hulk",
    lancamento: "O Incrível Hulk #1 (1962)",
    urlImagem:
      "https://static1.squarespace.com/static/51b3dc8ee4b051b96ceb10de/t/596c94c8b3db2bfde430c771/1500288203275/?format=2500w"
  },
  {
    nome: "Homem de Ferro",
    lancamento: "Tales of Suspense #39 (1963)",
    urlImagem:
      "https://i.pinimg.com/originals/52/08/ac/5208ac301eb3fb378dc6b69a5e94c6ec.jpg"
  }
];

/**
 * @api {get} /personagens Lista de Personagens
 * @apiGroup Personagens
 *
 * @apiSuccessExample {json} Sucesso
 *    HTTP/1.1 200 OK
 *    [{
 *          nome: "Homem-Aranha",
 *          lancamento: "Amazing Fantasy #15 (1962)",
 *          urlImagem: "http://supercinemaup.com/wp-content/uploads/2017/05/homem-aranha.jpg"
 *    }]
 *
 */
app.get("/personagens", function(req, res) {
  res.send(personagens);
});

app.listen(PORT, function() {
  console.log(`Listening on ${PORT}`);
});
