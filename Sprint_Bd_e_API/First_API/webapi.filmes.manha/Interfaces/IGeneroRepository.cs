using Microsoft.AspNetCore.SignalR;
using webapi.filmes.manha.Domains;

namespace webapi.filmes.manha.Interfaces
{
    /// <summary>
    /// Interface responsavel pelo repositorio GeneroRepository
    /// Implementar/Definir os metodos que serao implementados pelo GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        //tipoRetorno NomeMetodo(tipoParametro nomeParametro)


        /// <summary>
        /// Cadastrar um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto que sera cadastrado</param>
        void Cadastrar(GeneroDomain novoGenero);


        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        List<GeneroDomain> ListarTodos();


        /// <summary>
        /// Atualizar objeto existente passando o seu id pelo corpo da requisicao
        /// </summary>
        /// <param name="genero">objeto atualizado(novas informacoes)</param>
        void AtualizarIdCorpo(GeneroDomain genero);


        /// <summary>
        /// Atualizar objeto existente passando o seu id pela url
        /// </summary>
        /// <param name="id">Id do objeto que esta atualizado</param>
        /// <param name="genero">objeto atualizado(novas informacoes)</param>
        void AtualizarIdUrl(int id, GeneroDomain genero);


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
        GeneroDomain BuscarPorId(int id);


    }
}
