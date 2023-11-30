using webapi.inlock_games_dbFirst_manha.Domains;

namespace webapi.inlock_games_dbFirst_manha.Interfaces
{
    public interface IEstudioRepository
    {

        List<Estudio> Listar();


        Estudio BuscarPorId(Guid id);


        void Cadastrar(Estudio estudio);


        void Atualizar(Guid id, Estudio estudio);


        void Deletar(Guid id);


        List<Estudio> ListarComJogos();

    }
}
