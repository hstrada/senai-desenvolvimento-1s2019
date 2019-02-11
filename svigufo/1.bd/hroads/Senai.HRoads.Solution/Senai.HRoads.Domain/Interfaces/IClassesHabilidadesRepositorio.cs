using Senai.HRoads.Domain.Entidades;
using Senai.HRoads.Domain.Interfaces.Base;
using System;

namespace Senai.HRoads.Domain.Interfaces
{
    public interface IClassesHabilidadesRepositorio : ILeituraRepository<Classe_Habilidade>, IGravacaoRepository<Classe_Habilidade>
    {
        void Excluir(int Id_Classe, int Id_Habilidade);

        Classe_Habilidade BuscarPorId(int Id_Classe, int Id_Habilidade);
    }
}
