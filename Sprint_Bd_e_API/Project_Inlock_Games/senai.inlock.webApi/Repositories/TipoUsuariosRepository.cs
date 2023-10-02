using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repositories
{
    public class TipoUsuariosRepository : ITipoUsuariosRepository
    {
        //AUTENTICACAO PC PESSOAL WINDOWS
        //private string stringConexao = "Data Source = RICHARDS-PC\\SQLEXPRESS; Initial Catalog = inlock_games; Integrated Security = true;";


        //AUTENTICACAO SQL PC SENAI
        private string stringConexao = "Data Source = NOTE09-S15; Initial Catalog = inlock_games; User Id = sa; pwd = Senai@134";


        public void Cadastrar(TipoUsuariosDomain novoTipoUsuario)
        {
            //Declara a conexao passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query que sera executada 
                string queryInsert = "INSERT INTO TiposUsuario(Titulo) VALUES (@Titulo)";


                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", novoTipoUsuario.Titulo);

                    //Abre a conexao com o banco de dados
                    con.Open();

                    //Executar a query (queryInsert)
                    cmd.ExecuteNonQuery();
                }
            };
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM TiposUsuario WHERE @id = IdTipoUsuario";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TipoUsuariosDomain> ListarTodos()
        {
            List<TipoUsuariosDomain> listaTipoUsuario = new List<TipoUsuariosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdTipoUsuario, Titulo FROM TiposUsuario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuariosDomain TipoUsuarios = new TipoUsuariosDomain()
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),

                            Titulo = rdr["Titulo"].ToString(),
                        };

                        listaTipoUsuario.Add(TipoUsuarios);
                    }
                }
            }

            return listaTipoUsuario;

        }

    }
}
