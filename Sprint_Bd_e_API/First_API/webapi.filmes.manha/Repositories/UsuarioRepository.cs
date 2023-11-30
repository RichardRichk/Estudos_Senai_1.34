using System.Data.SqlClient;
using webapi.filmes.manha.Domains;
using webapi.filmes.manha.Interfaces;

namespace webapi.filmes.manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {


        //AUTENTICACAO PC SENAI
        private string stringConexao = "Data Source = NOTE09-S15; Initial Catalog = Filmes; User Id = sa; pwd = Senai@134";



        //AUTENTICACAO PC PESSOAL WINDOWS
        //private string stringConexao = "Data Source = RICHARDS-PC\\SQLEXPRESS; Initial Catalog = Filmes; Integrated Security = true;";



        //AUTENTICACAO PC PESSOAL SQLSERVER
        //private string stringConexao = "Data Source = RICHARDS-PC\\SQLEXPRESS; Initial Catalog = Filmes; User Id = sa; pwd = 1234";



        public UsuarioDomain Login(string email, string password)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryLogin = "SELECT Email, Senha, Permissao FROM Usuario WHERE Email = @Email AND Senha = @Senha";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {

                    cmd.Parameters.AddWithValue("@email", email);

                    cmd.Parameters.AddWithValue("@senha", password);

                    SqlDataReader rdr;

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            Email = rdr["Email"].ToString(),

                            Senha = rdr["Senha"].ToString(),

                            Permissao = rdr["Permissao"].ToString()
                        };

                        return usuario;
                    }

                    return null;

                }
            }
        }
    }
}
