using Microsoft.Extensions.Configuration;
using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Svigufo.WebApi.Infra.Data.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {

        private readonly string stringDeConexao;

        public InstituicaoRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            stringDeConexao = Configuration.GetConnectionString("DefaultConnection");
        }

        public IConfiguration Configuration { get; }

        public void Atualizar(InstituicaoDomain instituicaoDomain)
        {
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                string comandoSQL = "Update Instituicoes set Razao_Social = @Razao_Social" +
                    ", Nome_Fantasia = @Nome_Fantasia " +
                    ", Cnpj = @Cnpj " +
                    ", Logradouro = @Logradouro " +
                    ", Cep = @Cep " +
                    ", Uf = @Uf " +
                    ", Cidade = @Cidade " +
                    " Where Id = @Id";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                
                cmd.Parameters.AddWithValue("@Id", instituicaoDomain.Id);
                cmd.Parameters.AddWithValue("@Razao_Social", instituicaoDomain.RazaoSocial);
                cmd.Parameters.AddWithValue("@Nome_Fantasia", instituicaoDomain.NomeFantasia);
                cmd.Parameters.AddWithValue("@Cnpj", instituicaoDomain.Cnpj);
                cmd.Parameters.AddWithValue("@Logradouro", instituicaoDomain.Logradouro);
                cmd.Parameters.AddWithValue("@Cep", instituicaoDomain.Cep);
                cmd.Parameters.AddWithValue("@Uf", instituicaoDomain.Uf);
                cmd.Parameters.AddWithValue("@Cidade", instituicaoDomain.Cidade);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public InstituicaoDomain BuscarPorId(int id)
        {
            InstituicaoDomain instituicao = new InstituicaoDomain();
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                string comandoSQL = "Select * From Instituicoes Where Id = @Id";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader lerOsRegistros = cmd.ExecuteReader();
                if (lerOsRegistros.HasRows)
                {
                    while (lerOsRegistros.Read())
                    {
                        instituicao.Id = Int32.Parse(lerOsRegistros["Id"].ToString());
                        instituicao.RazaoSocial = lerOsRegistros["Razao_Social"].ToString();
                        instituicao.NomeFantasia = lerOsRegistros["Nome_Fantasia"].ToString();
                        instituicao.Cnpj = lerOsRegistros["Cnpj"].ToString();
                        instituicao.Cep = lerOsRegistros["Cep"].ToString();
                        instituicao.Uf = lerOsRegistros["Uf"].ToString();
                        instituicao.Cidade = lerOsRegistros["Cidade"].ToString();
                    }
                    return instituicao;
                }
                con.Close();
            }

            return null;
        }

        public void Cadastrar(InstituicaoDomain instituicaoDomain)
        {
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                string comandoSQL = "Insert into Instituicoes (Razao_Social, Nome_Fantasia, Cnpj, Logradouro, Cep, Uf, Cidade) Values(@Razao_social, @Nome_Fantasia, @Cnpj, @Logradouro, @Cep, @Uf, @Cidade)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.Parameters.AddWithValue("@Razao_Social", instituicaoDomain.RazaoSocial);
                cmd.Parameters.AddWithValue("@Nome_Fantasia", instituicaoDomain.NomeFantasia);
                cmd.Parameters.AddWithValue("@Cnpj", instituicaoDomain.Cnpj);
                cmd.Parameters.AddWithValue("@Logradouro", instituicaoDomain.Logradouro);
                cmd.Parameters.AddWithValue("@Cep", instituicaoDomain.Cep);
                cmd.Parameters.AddWithValue("@Uf", instituicaoDomain.Uf);
                cmd.Parameters.AddWithValue("@Cidade", instituicaoDomain.Cidade);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
