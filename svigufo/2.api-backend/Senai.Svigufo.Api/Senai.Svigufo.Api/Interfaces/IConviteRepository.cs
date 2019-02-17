using Senai.Svigufo.Api.Domains;
using System.Collections.Generic;

namespace Senai.Svigufo.Api.Interfaces
{
    public interface IConviteRepository
    {
        /// <summary>
        /// Listar apenas os meus convites
        /// </summary>
        /// <returns>Lista dos meus convites</returns>
        List<ConviteDomain> ListarMeusConvites(int id);

        /// <summary>
        /// Listar todos os convites da plataforma
        /// </summary>
        /// <returns>Listar todos os convites</returns>
        List<ConviteDomain> Listar();
    }
}
