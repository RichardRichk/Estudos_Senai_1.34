using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {

        private readonly EventContext _eventContext;


        public TiposUsuarioRepository() 
        { 
            _eventContext= new EventContext();
        }


        public void Atualizar(Guid id, TiposUsuario tipoUsuario)
        {

            TiposUsuario tipoUsuarioBuscado = _eventContext.TiposUsuario.Find(id);

            if (tipoUsuarioBuscado != null)
            {
                tipoUsuarioBuscado.Titulo = tipoUsuario.Titulo;

                _eventContext.TiposUsuario.Update(tipoUsuarioBuscado);

                _eventContext.SaveChanges();
            }

        }

        public TiposUsuario BuscarPorId(Guid id)
        {
            TiposUsuario tipoUsuarioBuscado = _eventContext.TiposUsuario.Find(id);

            return tipoUsuarioBuscado;
        }

        public void Cadastrar(TiposUsuario tipoUsuario)
        {
            _eventContext.TiposUsuario.Add(tipoUsuario);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposUsuario tipoUsuarioBuscado = _eventContext.TiposUsuario.Find(id);

            _eventContext.TiposUsuario.Remove(tipoUsuarioBuscado);

            _eventContext.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
           return _eventContext.TiposUsuario.ToList();
        }
    }
}
