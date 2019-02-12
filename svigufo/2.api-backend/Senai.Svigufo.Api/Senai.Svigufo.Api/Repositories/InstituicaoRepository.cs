using Senai.Svigufo.Api.Domains;
using Senai.Svigufo.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.Svigufo.Api.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private string stringDeConexao = "Data Source=localhost;Initial Catalog=SENAI_SVIGUFO;Integrated Security=True";

        public void Alterar(InstituicaoDomain instituicao)
        {
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                string comandoSQL = "UPDATE INSTITUICOES SET RAZAO_SOCIAL = @RAZAO_SOCIAL" +
                    ", NOME_FANTASIA = @NOME_FANTASIA " +
                    ", CNPJ = @CNPJ " +
                    ", LOGRADOURO = @LOGRADOURO " +
                    ", CEP = @CEP " +
                    ", UF = @UF " +
                    ", CIDADE = @CIDADE " +
                    " WHERE ID = @ID";

                SqlCommand cmd = new SqlCommand(comandoSQL, con);

                cmd.Parameters.AddWithValue("@ID", instituicao.Id);
                cmd.Parameters.AddWithValue("@RAZAO_SOCIAL", instituicao.RazaoSocial);
                cmd.Parameters.AddWithValue("@NOME_FANTASIA", instituicao.NomeFantasia);
                cmd.Parameters.AddWithValue("@CNPJ", instituicao.CNPJ);
                cmd.Parameters.AddWithValue("@LOGRADOURO", instituicao.Logradouro);
                cmd.Parameters.AddWithValue("@CEP", instituicao.Cep);
                cmd.Parameters.AddWithValue("@UF", instituicao.Uf);
                cmd.Parameters.AddWithValue("@CIDADE", instituicao.Cidade);

                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public InstituicaoDomain BuscarPorId(int id)
        {
            InstituicaoDomain instituicao = new InstituicaoDomain();
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                string comandoSQL = "SELECT * FROM INSTITUICOES WHERE ID = @ID ORDER BY ID ASC";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                SqlDataReader lerOsRegistros = cmd.ExecuteReader();
                if (lerOsRegistros.HasRows)
                {
                    while (lerOsRegistros.Read())
                    {
                        instituicao.Id = Int32.Parse(lerOsRegistros["ID"].ToString());
                        instituicao.RazaoSocial = lerOsRegistros["RAZAO_SOCIAL"].ToString();
                        instituicao.NomeFantasia = lerOsRegistros["NOME_FANTASIA"].ToString();
                        instituicao.CNPJ = lerOsRegistros["CNPJ"].ToString();
                        instituicao.Cep = lerOsRegistros["CEP"].ToString();
                        instituicao.Logradouro = lerOsRegistros["LOGRADOURO"].ToString();
                        instituicao.Uf = lerOsRegistros["UF"].ToString();
                        instituicao.Cidade = lerOsRegistros["CIDADE"].ToString();
                    }
                    return instituicao;
                }
            }

            return null;
        }

        public void Cadastrar(InstituicaoDomain instituicao)
        {
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                string comandoSQL = "INSERT INTO INSTITUICOES (RAZAO_SOCIAL, NOME_FANTASIA, CNPJ, LOGRADOURO, CEP, UF, CIDADE) VALUES( @RAZAO_SOCIAL, @NOME_FANTASIA, @CNPJ, @LOGRADOURO, @CEP, @UF, @CIDADE)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.Parameters.AddWithValue("@RAZAO_SOCIAL", instituicao.RazaoSocial);
                cmd.Parameters.AddWithValue("@NOME_FANTASIA", instituicao.NomeFantasia);
                cmd.Parameters.AddWithValue("@CNPJ", instituicao.CNPJ);
                cmd.Parameters.AddWithValue("@LOGRADOURO", instituicao.Logradouro);
                cmd.Parameters.AddWithValue("@CEP", instituicao.Cep);
                cmd.Parameters.AddWithValue("@UF", instituicao.Uf);
                cmd.Parameters.AddWithValue("@CIDADE", instituicao.Cidade);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<InstituicaoDomain> Listar()
        {
            string queryASerExecutada = "SELECT ID, NOME_FANTASIA, RAZAO_SOCIAL, CNPJ, CEP, LOGRADOURO, UF, CIDADE FROM INSTITUICOES";

            // crio uma nova lista
            List<InstituicaoDomain> listaInstituicoes = new List<InstituicaoDomain>();

            // garante que os recursos sejam fechados e descartados quando o código será encerrado
            // sqlconnection cria uma instância do objeto
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                // permite que você crie queries e envie para o banco de dados
                using (SqlCommand cmd = new SqlCommand(queryASerExecutada, con))
                {
                    // para determinar que é do tipo texto
                    // cmd.CommandType = CommandType.Text;
                    con.Open();
                    // retorna um conjunto de resultados do banco de dados
                    SqlDataReader rdr = cmd.ExecuteReader();
                    // enquanto tiver registros
                    while (rdr.Read())
                    {
                        // cria um novo objeto e insere na lista
                        InstituicaoDomain instituicao = new InstituicaoDomain
                        {
                            Id = Convert.ToInt32(rdr["ID"]),
                            NomeFantasia = rdr["NOME_FANTASIA"].ToString(),
                            RazaoSocial = rdr["RAZAO_SOCIAL"].ToString(),
                            CNPJ = rdr["CNPJ"].ToString(),
                            Cep = rdr["CEP"].ToString(),
                            Logradouro = rdr["LOGRADOURO"].ToString(),
                            Uf = rdr["UF"].ToString(),
                            Cidade = rdr["CIDADE"].ToString(),
                        };

                        // adiciona cada evento na lista
                        listaInstituicoes.Add(instituicao);
                    }
                }
            }
            // retorna a própria lista
            return listaInstituicoes;
        }
    }
}
