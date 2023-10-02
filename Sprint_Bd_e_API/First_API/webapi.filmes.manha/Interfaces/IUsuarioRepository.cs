using webapi.filmes.manha.Domains;

namespace webapi.filmes.manha.Interfaces
{
    public interface IUsuarioRepository
    {
        public UsuarioDomain Login(string email, string senha);
    }
}
