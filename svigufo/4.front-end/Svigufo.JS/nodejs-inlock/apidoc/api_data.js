define({ "api": [
  {
    "type": "get",
    "url": "/personagens",
    "title": "Lista de Personagens",
    "group": "Personagens",
    "success": {
      "examples": [
        {
          "title": "Sucesso",
          "content": "HTTP/1.1 200 OK\n[{\n      nome: \"Homem-Aranha\",\n      lancamento: \"Amazing Fantasy #15 (1962)\",\n      urlImagem: \"http://supercinemaup.com/wp-content/uploads/2017/05/homem-aranha.jpg\"\n}]",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./app.js",
    "groupTitle": "Personagens",
    "name": "GetPersonagens"
  }
] });
