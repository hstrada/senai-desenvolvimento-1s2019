using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Senai.HRoads.Domain.Entidades;
using Senai.HRoads.Domain.Interfaces;

namespace Senai.HRoads.Infra.Data.Repositorios
{
    public class HabilidadesRepositorio : IHabilidadesRepositorio
    {
        public void Atualizar(Habilidade dados)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    conexao.Query<Classe>("UPDATE HABILIDADES SET NOME = @NOME, ID_TIPO_HABILIDADE = @ID_TIPO_HABILIDADE WHERE ID = @ID", 
                                                    new { NOME = dados.Nome, ID_TIPO_HABILIDADE = dados.Id_Tipo_Habilidade, ID = dados.Id });
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
                    conexao.QueryFirstOrDefault<Tipo_Habilidade>("DELETE HABILIDADES WHERE ID = @ID", new { ID = Id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Inserir(Habilidade dados)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    conexao.Query<Tipo_Habilidade>("INSERT INTO HABILIDADES VALUES(@NOME, @ID_TIPO_HABILIDADE)", new { NOME = dados.Nome, ID_TIPO_HABILIDADE = dados.Id_Tipo_Habilidade });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Habilidade> Listar()
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {

                    string sql = "SELECT HAB.*, TH.* FROM HABILIDADES HAB JOIN TIPOS_HABILIDADES TH ON HAB.ID_TIPO_HABILIDADE = TH.ID ORDER BY HAB.ID";


                        var habilidades = conexao.Query<Habilidade, Tipo_Habilidade, Habilidade>(
                                sql,
                                (hab, th) =>
                                {
                                    hab.TipoHabilidade = th;
                                    return hab;
                                },
                                splitOn: "ID_TIPO_HABILIDADE")
                            .Distinct()
                            .ToList();
                    

                    return conexao.Query<Habilidade>("SELECT ID, NOME, ID_TIPO_HABILIDADE FROM HABILIDADES ORDER BY ID");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Habilidade BuscarPorId(int Id)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    return conexao.QueryFirstOrDefault<Habilidade>("SELECT ID, NOME, ID_TIPO_HABILIDADE FROM HABILIDADES where ID = @ID", new { ID = Id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
