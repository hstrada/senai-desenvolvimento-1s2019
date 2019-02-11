using Senai.Svigufo.Api.Domains;
using Senai.Svigufo.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Senai.Svigufo.Api.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {

        private string stringDeConexao = "Data Source=localhost;Initial Catalog=SENAI_SVIGUFO;Integrated Security=True";

        public List<TipoEventoDomain> Listar()
        {
            string queryASerExecutada = "SELECT ID, TITULO FROM TIPOS_EVENTOS";

            // crio uma nova lista
            List<TipoEventoDomain> listaTiposEventos = new List<TipoEventoDomain>();

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
                        TipoEventoDomain tipoEvento = new TipoEventoDomain
                        {
                            Id = Convert.ToInt32(rdr["ID"]),
                            Nome = rdr["TITULO"].ToString()
                        };

                        // adiciona cada evento na lista
                        listaTiposEventos.Add(tipoEvento);
                    }
                }
            }
            // retorna a própria lista
            return listaTiposEventos;
        }

        public TipoEventoDomain BuscarPorId(int id)
        {

            string queryASerExecutada = "SELECT ID, TITULO FROM TIPOS_EVENTOS WHERE ID = @ID";

            // crio um novo evento
            TipoEventoDomain tipoEvento = new TipoEventoDomain();
            // abro uma nova instância na conexão
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                // um novo comando que será executado na conexão
                using (SqlCommand cmd = new SqlCommand(queryASerExecutada, con))
                {
                    // preciso passar o parâmetro que recebi, para a query a ser executada
                    cmd.Parameters.AddWithValue("@ID", id);
                    // abre a conexão
                    con.Open();
                    // lê os registros
                    SqlDataReader lerOsRegistros = cmd.ExecuteReader();
                    // mas agora eu posso verificar se tenho linhas
                    if (lerOsRegistros.HasRows)
                    {
                        // enquanto eu tiver registros, no caso, somente um, coloco os dados no objeto criado
                        while (lerOsRegistros.Read())
                        {
                            tipoEvento.Id = Convert.ToInt32(lerOsRegistros["ID"].ToString());
                            tipoEvento.Nome = lerOsRegistros["TITULO"].ToString();
                        }
                        return tipoEvento;
                    }
                }
            }

            // caso não tenha registro, o valor será nulo
            return null;
        }

        public void Cadastrar(TipoEventoDomain tipoEvento)
        {
            using (SqlConnection con = new SqlConnection(stringDeConexao))
            {
                // string queryASerExecutada = "INSERT INTO TIPOS_EVENTOS (TITULO) VALUES (' " + tipoEvento.Nome + " ')";
                string queryASerExecutada = "INSERT INTO TIPOS_EVENTOS (TITULO) VALUES (@TITULO)";

                SqlCommand cmd = new SqlCommand(queryASerExecutada, con);
                cmd.Parameters.AddWithValue("@TITULO", tipoEvento.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Alterar(TipoEventoDomain tipoEvento)
        {
            throw new NotImplementedException();
        }
        
        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
