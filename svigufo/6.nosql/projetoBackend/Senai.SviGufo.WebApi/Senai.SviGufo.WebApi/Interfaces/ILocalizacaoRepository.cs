using Senai.SviGufo.WebApi;
using Senai.SviGufo.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Interfaces
{
    public interface ILocalizacaoRepository
    {
        void Cadastrar(LocalizacaoDomain localizacao);

        List<LocalizacaoDomain> ListarTodos();

        List<LocalizacaoDomain> BuscarPorIdUsuario(int id);
    }
}
