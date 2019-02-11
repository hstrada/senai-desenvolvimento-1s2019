using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Senai.HRoads.Domain.Entidades;
using Senai.HRoads.Domain.Interfaces;

namespace Senai.HRoads.Infra.Data.Repositorios
{
    public class TiposHabilidadesRepositorio : ITiposHabilidadesRepositorio
    {
        public void Atualizar(Tipo_Habilidade dados)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    conexao.Query<Tipo_Habilidade>("UPDATE TIPOS_HABILIDADES SET NOME = @NOME WHERE ID = @ID", new { NOME = dados.Nome, ID = dados.Id });
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
                    conexao.Query<Tipo_Habilidade>("DELETE TIPOS_HABILIDADES WHERE ID = @ID", new { ID = Id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Inserir(Tipo_Habilidade dados)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    conexao.Query<Tipo_Habilidade>("INSERT INTO TIPOS_HABILIDADES VALUES(@NOME)", new { NOME = dados.Nome });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Tipo_Habilidade> Listar()
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    return conexao.Query<Tipo_Habilidade>("SELECT ID, NOME FROM TIPOS_HABILIDADES ORDER BY ID");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Tipo_Habilidade BuscarPorId(int Id)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    return conexao.QueryFirstOrDefault<Tipo_Habilidade>("SELECT ID, NOME FROM TIPOS_HABILIDADES WHERE ID = @ID", new { ID = Id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
