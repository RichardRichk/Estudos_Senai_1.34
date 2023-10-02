using System.Data.SqlClient;
using webapi.filmes.manha.Domains;
using webapi.filmes.manha.Interfaces;

namespace webapi.filmes.manha.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {

        //AUTENTICACAO PC SENAI

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




        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryAtualizarIdCorpo = "UPDATE Filme SET Titulo = @Titulo, IdGenero = @IdGenero WHERE IdFilme = @Id";

                using (SqlCommand cmd = new SqlCommand(queryAtualizarIdCorpo, con))
                {
                    cmd.Parameters.AddWithValue("@id", filme.IdFilme);

                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryAtualizarIdUrl = "UPDATE Filme SET Titulo = @Titulo, IdGenero = @IdGenero WHERE IdFilme = @Id";

                using (SqlCommand cmd = new SqlCommand(queryAtualizarIdUrl, con)) 
                { 
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public FilmeDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT IdFilme , Titulo, Genero.Nome, Genero.IdGenero FROM Filme LEFT JOIN Genero ON Filme.IdGenero = Genero.IdGenero WHERE IdFilme = @id";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filmeBuscado = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),

                            IdGenero= Convert.ToInt32(rdr["IdGenero"]),

                            Titulo = rdr["Titulo"].ToString(),

                            Genero = new GeneroDomain()
                            {
                                //IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                                Nome = rdr["Nome"].ToString()
                            }
                        };

                        return filmeBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Filme(Titulo, IdGenero) VALUES(@Titulo, @IdGenero)";


                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);

                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.Genero.IdGenero);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Filme WHERE @id = IdFilme";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> ListaFilmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM Filme INNER JOIN Genero ON Filme.IdGenero = Genero.IdGenero;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),

                            IdGenero = Convert.ToInt32(rdr[1]),

                            Titulo = rdr["Titulo"].ToString(),

                            Genero = new GeneroDomain()
                            {
                                //IdGenero = Convert.ToInt32(rdr[1]),
                                Nome = rdr["Nome"].ToString(),
                            }

                        };

                        ListaFilmes.Add(filme);
                    }
                }
            }

            return ListaFilmes;
        }
    }
}
