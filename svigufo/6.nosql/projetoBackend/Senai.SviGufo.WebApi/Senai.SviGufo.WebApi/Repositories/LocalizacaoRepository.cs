using MongoDB.Driver;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using Senai.SviGufo.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Repositories
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {

        private readonly IMongoCollection<LocalizacaoDomain> _localizacoes;

        public LocalizacaoRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("svigufo");
            _localizacoes = database.GetCollection<LocalizacaoDomain>("mapas");
        }

        public void Cadastrar(LocalizacaoDomain localizacao)
        {
            _localizacoes.InsertOne(localizacao);
        }

        public List<LocalizacaoDomain> ListarTodos()
        {
            return _localizacoes.Find(localizacao => true).ToList();
        }
    }
}
