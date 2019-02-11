using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Senai.HRoads.Domain.Entidades;
using Senai.HRoads.Domain.Interfaces;

namespace Senai.HRoads.Infra.Data.Repositorios
{
    public class PersonagensRepositorio : IPersonagensRepositorio
    {
        public void Atualizar(Personagem dados)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    conexao.Query<Tipo_Habilidade>("UPDATE [dbo].[PERSONAGENS] SET [NOME] = @NOME,[CAP_MAX_VIDA] = @CAP_MAX_VIDA,[CAP_MAX_MANA] = @CAP_MAX_MANA," + 
                                                                    "[DT_CRIACAO] = @DT_CRIACAO,[DT_ATUALIZACAO] = @DT_ATUALIZACAO, [ID_CLASSE] = @ID_CLASSE WHERE ID = @ID",
                                                                    new
                                                                    {   NOME = dados.Nome,
                                                                        CAP_MAX_VIDA = dados.Cap_Max_Vida,
                                                                        CAP_MAX_MANA = dados.Cap_Max_Mana,
                                                                        DT_CRIACAO = dados.DataCriacao,
                                                                        DT_ATUALIZACAO = dados.DataAtualizacao,
                                                                        ID_CLASSE = dados.Id_Classe,
                                                                        ID = dados.Id
                                                                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(int Id)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    conexao.QueryFirstOrDefault<Tipo_Habilidade>("DELETE PERSONAGENS WHERE ID = @ID", new { ID = Id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Inserir(Personagem dados)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    conexao.Query<Personagem>("INSERT INTO[dbo].[PERSONAGENS]([NOME],[CAP_MAX_VIDA],[CAP_MAX_MANA],[DT_CRIACAO],[DT_ATUALIZACAO],[ID_CLASSE])" +
                                                            "VALUES(@NOME, @CAP_MAX_VIDA, @CAP_MAX_MANA, @DT_CRIACAO, @DT_ATUALIZACAO, @ID_CLASSE)",
                                                            new { NOME = dados.Nome
                                                                , CAP_MAX_VIDA = dados.Cap_Max_Vida
                                                                , CAP_MAX_MANA = dados.Cap_Max_Mana
                                                                , DT_CRIACAO = dados.DataCriacao
                                                                , DT_ATUALIZACAO = dados.DataAtualizacao
                                                                , ID_CLASSE = dados.Id_Classe });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Personagem> Listar()
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    return conexao.Query<Personagem>("SELECT [ID], [NOME], [CAP_MAX_VIDA], [CAP_MAX_MANA], [DT_CRIACAO] AS DATACRIACAO, [DT_ATUALIZACAO] AS DATAATUALIZACAO, [ID_CLASSE] FROM[dbo].[PERSONAGENS] GO");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Personagem BuscarPorId(int Id)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    return conexao.QueryFirstOrDefault<Personagem>("SELECT [ID], [NOME], [CAP_MAX_VIDA], [CAP_MAX_MANA], [DT_CRIACAO] AS DATACRIACAO, [DT_ATUALIZACAO] AS DATAATUALIZACAO, [ID_CLASSE] FROM[dbo].[PERSONAGENS] WHERE ID = @ID",new { ID = Id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
