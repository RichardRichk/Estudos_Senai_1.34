using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly EventContext _eventContext;


        public TipoEventoRepository()
        {
            _eventContext = new EventContext();
        }


        public void Atualizar(Guid id, TiposEvento tipoEvento)
        {
            TiposEvento tipoAntigo = _eventContext.TiposEvento.FirstOrDefault(z => z.IdTipoEvento == id)!;

            if (tipoAntigo != null)
            {
                tipoAntigo.Titulo = tipoEvento.Titulo;

                _eventContext.TiposEvento.Update(tipoAntigo);
                _eventContext.SaveChanges();
            }
        }



        public TiposEvento BuscarPorId(Guid id)
        {
            TiposEvento tipoBuscado = _eventContext.TiposEvento.FirstOrDefault(z => z.IdTipoEvento == id)!;

            if (tipoBuscado != null)
            {
                return tipoBuscado;
            }
            return null!;
        }



        public void Cadastrar(TiposEvento tipoEvento)
        {
            if (tipoEvento != null)
            {
                _eventContext.TiposEvento.Add(tipoEvento);
                _eventContext.SaveChanges();
            }
        }



        public void Deletar(Guid id)
        {
            TiposEvento tipoDeletado = _eventContext.TiposEvento.FirstOrDefault(z => z.IdTipoEvento == id)!;

            _eventContext.TiposEvento.Remove(tipoDeletado);

            _eventContext.SaveChanges();

        }

        public List<TiposEvento> Listar()
        {
            return _eventContext.TiposEvento.ToList();
        }
    }
}
