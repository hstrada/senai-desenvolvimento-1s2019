using Senai.Svigufo.Api.Domains;
using System.Collections.Generic;

namespace Senai.Svigufo.Api.Interfaces
{
    public interface IInstituicaoRepository
    {
        /// <summary>
        /// Cadastrar uma nova instituição
        /// </summary>
        /// <param name="instituicao">InstituicaoDomain</param>
        void Cadastrar(InstituicaoDomain instituicao);
        
        /// <summary>
        /// Alterar uma instituição existente
        /// </summary>
        /// <param name="instituicao">InstituicaoDomain</param>
        void Alterar(InstituicaoDomain instituicao);
        
        /// <summary>
        /// Buscar somente uma instituição
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>InsittuicaoDomain</returns>
        InstituicaoDomain BuscarPorId(int id);
        
        /// <summary>
        /// Listar todas as instituições
        /// </summary>
        /// <returns>Uma lista de instituições</returns>
        List<InstituicaoDomain> Listar();
    }
}
