using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Senai.HRoads.Domain.Entidades;
using Senai.HRoads.Domain.Interfaces;

namespace Senai.HRoads.Infra.Data.Repositorios
{
    public class ClassesRepositorio : IClassesRepositorio
    {
        public void Atualizar(Classe dados)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    conexao.Update(new Classe { Id = dados.Id, Nome = dados.Nome });
                    //conexao.Query<ClassesDominio>("UPDATE CLASSES SET NOME = @NOME WHERE ID = @ID", new { NOME = dados.Nome, ID = dados.Id });
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
                    conexao.Delete(new Classe { Id = 1 });
                    //conexao.QueryFirstOrDefault<ClassesDominio>("DELETE CLASSES WHERE ID = @ID", new { ID = Id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Inserir(Classe dados)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    conexao.Insert(new Classe { Nome =  dados.Nome});
                    //conexao.Query<ClassesDominio>("INSERT INTO CLASSES VALUES(@NOME)", new { NOME = dados.Nome });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Classe> Listar()
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    return conexao.GetAll<Classe>().ToList();
                    //return conexao.Query<ClassesDominio>("SELECT ID, NOME FROM CLASSES ORDER BY ID");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Classe BuscarPorId(int Id)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=SENAI_HROADS;Integrated Security=True"))
                {
                    return conexao.Get<Classe>(Id);
                    //return conexao.QueryFirstOrDefault<ClassesDominio>("SELECT ID, NOME FROM CLASSES WHERE ID = @ID ORDER BY ID", new { ID = Id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
