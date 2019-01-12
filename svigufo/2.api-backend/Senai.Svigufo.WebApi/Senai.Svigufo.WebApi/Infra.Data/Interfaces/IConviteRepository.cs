using Senai.Svigufo.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Infra.Data.Interfaces
{
    public interface IConviteRepository
    {
        #region Gravação
        void EntrarEvento(ConviteDomain domain);
        #endregion
    }
}
