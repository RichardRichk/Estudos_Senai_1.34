using webapi.filmes.manha.Domains;

namespace webapi.filmes.manha.Interfaces
{

    /// <summary>
    /// Interface responsavel pelo repositorio GeneroRepository
    /// Implementar/Definir os metodos que serao implementados pelo GeneroRepository
    /// </summary>
    public interface IFilmeRepository
    {
            //tipoRetorno NomeMetodo(tipoParametro nomeParametro)


            /// <summary>
            /// Cadastrar um novo Filme
            /// </summary>
            /// <param name="novoFilme">Objeto que sera cadastrado</param>
            void Cadastrar(FilmeDomain novoFilme);


            /// <summary>
            /// Listar todos os objetos cadastrados
            /// </summary>
            /// <returns>Lista com os objetos</returns>
            List<FilmeDomain> ListarTodos();


            /// <summary>
            /// Atualizar objeto existente passando o seu id pelo corpo da requisicao
            /// </summary>
            /// <param name="genero">objeto atualizado(novas informacoes)</param>
            void AtualizarIdCorpo(FilmeDomain filme);


            /// <summary>
            /// Atualizar objeto existente passando o seu id pela url
            /// </summary>
            /// <param name="id">Id do objeto que esta atualizado</param>
            /// <param name="genero">objeto atualizado(novas informacoes)</param>
            void AtualizarIdUrl(int id, FilmeDomain filme);


            /// <summary>
            /// deletar um objeto
            /// </summary>
            /// <param name="id">id do objeto que sera deletado</param>
            void Deletar(int id);


            /// <summary>
            /// busca um objeto atraves do seu id
            /// </summary>
            /// <param name="id">id do objeto a ser buscado</param>
            /// <returns>Objeto buscado</returns>
            FilmeDomain BuscarPorId(int id);


    }

}

