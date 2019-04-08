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
          "content": "HTTP/1.1 200 OK\n[{\n      nome: \"\",\n      descricao: \"\",\n      localizacao: \"\",\n      urlImagem: \"\"\n}]",
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
