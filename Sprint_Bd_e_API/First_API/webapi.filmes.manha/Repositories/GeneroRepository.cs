using System.Data.SqlClient;
using System.Text.Json.Nodes;
using webapi.filmes.manha.Domains;
using webapi.filmes.manha.Interfaces;

namespace webapi.filmes.manha.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {

        //AUTENTICACO PC SENAI

        /// <summary>
        /// Data Source : Nome do servidor;
        /// Initial Catalog = Nome do Banco de Dados;
        /// Autenticacao:
        ///     - Windows: Integrated Security = true
        ///     - SqlServer: User Id = User; pwd = Senha
        /// </summary>

        private string stringConexao = "Data Source = NOTE09-S15; Initial Catalog = Filmes; User Id = sa; pwd = Senai@134";
        //Integrated Security = true



        //AUTENTICACAO PC PESSOAL WINDOWS
        //private string stringConexao = "Data Source = RICHARDS-PC\\SQLEXPRESS; Initial Catalog = Filmes; Integrated Security = true;";



        //AUTENTICACAO PC PESSOAL SQLSERVER
        //private string stringConexao = "Data Source = RICHARDS-PC\\SQLEXPRESS; Initial Catalog = Filmes; User Id = sa; pwd = 1234";



        /// <summary>
        /// Atualizar genero a partir do corpo 
        /// </summary>
        /// <param name="genero">Objeto com as informacoes que serao atualizadas</param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryAtualizarIdCorpo = "UPDATE Genero SET Nome = @Nome WHERE IdGenero = @id";

                using (SqlCommand cmd = new SqlCommand(queryAtualizarIdCorpo, con))
                {
                    cmd.Parameters.AddWithValue("@id", genero.IdGenero);

                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }



        /// <summary>
        /// Atualizar genero atraves do ID
        /// </summary>
        /// <param name="id">id do genero a ser atualizado</param>
        /// <param name="genero">objeto com as informacoes que serao atualizadas</param>
        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryAtualizarIdUrl = "UPDATE Genero SET Nome = @Nome WHERE IdGenero = @id";

                using (SqlCommand cmd = new SqlCommand(queryAtualizarIdUrl, con))
                {

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }




        /// <summary>
        /// Buscar um genero atraves de um if=d
        /// </summary>
        /// <param name="id">id do genero a ser herdado</param>
        /// <returns>objeto herdado ou null cado nao seja encontrado</returns>
        /// <exception cref="NotImplementedException"></exception>
        public GeneroDomain BuscarPorId(int id)
        {
            //declara a conexao passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query a ser executada
                string querySelectById = "SELECT IdGenero, Nome FROM Genero WHERE IdGenero = @IdGenero";

                //Abre a conexao com o banco de dados
                con.Open();

                //Declara o sqlReader rdr para receber os valores do banco de dados
                SqlDataReader rdr;

                //declara o sqlCommand cmd passando a query que sera execur=tada e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    //passa o valor para o parametro @IdGenero
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    //Executa a query e armazena dados no rdr
                    rdr = cmd.ExecuteReader();

                    //Verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        //se sim, instancia um novo objeto generoBuscado do tipo GeneroDomain
                        GeneroDomain generoBuscado = new GeneroDomain
                        {
                            //atribui a propriedade IdGenero o valor da coluna "IdGenero" da tabela do banco de dados
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            //Atribui a propriedade nome o valor da coluna "Nome" da tabela do banco de dados
                            Nome = rdr["Nome"].ToString()
                        };

                        //Retorna o generoBuscado com os dados obtidos
                        return generoBuscado;
                    }

                    //Se nao, retorna null
                    return null;
                }
            }
        }




        /// <summary>
        /// Cadastrar um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto com as informacoes que serao cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {

            //Declara a conexao passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query que sera executada 
                string queryInsert = "INSERT INTO Genero(Nome) VALUES (@Nome)";
                //string queryInsert = "INSERT INTO Genero(Nome) VALUES ('" + novoGenero.Nome + "')";


                //Declara o Sql command passando a query que sera executada e a conexao com o bd(Banco de Dados)
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Passa o valor do parametro @Nome 
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    //Abre a conexao com o banco de dados
                    con.Open();

                    //Executar a query (queryInsert)
                    cmd.ExecuteNonQuery();
                }
            }
        }




        public void Deletar(int id)
        {
            //Declara a SqlConnection passando a string de conexao com parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Genero WHERE @id = IdGenero";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }




        /// <summary>
        /// Listar todos os objetos generos
        /// </summary>
        /// <returns>Lista de objetos (generos)</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<GeneroDomain> ListarTodos()
        {

            //Cria uma lista de objetos do tipo genero
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();


            //Declara a SqlConnection passando a string de conexao com parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a instrucao a ser executada
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

                //Abre a conexao com o bamco de dados
                con.Open();

                //Declara o SqlDataReader para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query qye sera executada e a conexao com o bd(Banco de Dados
                using (SqlCommand sqlcmd = new SqlCommand(querySelectAll, con))
                {

                    //Executs a query e armazena os dados do rdr
                    rdr = sqlcmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //Atribui a propriedade IdGenero o valor recebido no rdr
                            IdGenero = Convert.ToInt32(rdr[0]),


                            Nome = rdr["Nome"].ToString()
                            //Convert.ToString(rdr["Nome"])
                        };

                        //Adiciona cada objeto dentro da lista
                        listaGeneros.Add(genero);
                    }
                }
            }


            //retorna a lista de generos
            return listaGeneros;
        }
    }
}
