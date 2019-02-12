using Senai.Svigufo.Api.Domains;
using System.Collections.Generic;

namespace Senai.Svigufo.Api.Interfaces
{
    public interface IInstituicaoRepository
    {
        void Cadastrar(InstituicaoDomain instituicao);
        void Alterar(InstituicaoDomain instituicao);
        InstituicaoDomain BuscarPorId(int id);
        List<InstituicaoDomain> Listar();
    }
}
