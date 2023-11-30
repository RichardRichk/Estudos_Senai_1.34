using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.manha.Domains;
using webapi.filmes.manha.Interfaces;
using webapi.filmes.manha.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.filmes.manha.Controllers
{
    //Define que a nota de uma requisicao sera no seguinte formato:
    //Dominio/API/Nome do controller
    //Exemplo: https://localhost:500/api/genero
    [Route("api/[controller]")]

    //Define que e um controlador de API
    [ApiController]

    //Define que o tipo de resposta da API sera no formato JSON
    [Produces("application/json")]

    //Metodo controlador que herda da controller base
    //Onde sera criado os Endpoints
    public class GeneroController : ControllerBase
    {

        /// <summary>
        /// Objeto _generoRepository que ira receber todos os metodos definidos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }


        /// <summary>
        /// Instancia o objeto _generoRepository para que haja referencia aos metodos do repositorio
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// EndPoint que aciona o metodo ListarTodos no repositorio e retorna a resposta para o usuario(Front-End)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize (Roles = "ADM")]

        public IActionResult GetListarTodos()
        {

            try
            {
                //Cria uma lista que recebe os dados da requisicao 
                List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

                //retorna a lista no formato JSON com o status onde Ok(200)
                return StatusCode(200, listaGeneros);
                //return Ok(listaGeneros);
            }
            catch (Exception erro)
            {
                //Retorna com status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }

        }

        /// <summary>
        /// EndPoint que aciona o metodo de cadastro de genero
        /// </summary>
        /// <param name="novoGenero">Objeto recebido para requisicao</param>
        /// <returns>status code 201(Created)</returns>
        [HttpPost]

        public IActionResult PostCadastrar(GeneroDomain novoGenero)
        {

            try
            {
                //Fazendo a chamada para o metodo cadastrar passando o objeto como parametro
                _generoRepository.Cadastrar(novoGenero);

                return StatusCode(201);

            }
            catch (Exception erro)
            {
                //Retorna com status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// EndPoint que aciona o metodo de deletar genero
        /// </summary>
        /// <param name="id">Id do genero a ser deletado</param>
        /// <returns>Status Code</returns>
        [HttpDelete("{@Id}")]
        public IActionResult DeleteDeletar(int id) 
        {
            try
            {
                _generoRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// EndPoint que aciona o metodo de buscar por id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Status code e objeto caso encontrado</returns>
        [HttpGet("{id}")]

        public IActionResult GetBuscarPorId(int id)
        {
            try
            {
                //Cria um objeto generoBuscado que ira receber o genero buscado no banco de dados
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

                if (generoBuscado == null)
                {
                    return NotFound("Nenhum Genero foi encontrado");
                }

                return Ok(generoBuscado);
            }
            catch (Exception erro)
            {
                //Retorna com status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }



        /// <summary>
        /// Atualizar genero atraves do ID
        /// </summary>
        /// <param name="id">id do genero a ser atualizado</param>
        /// <param name="genero">objeto com as informacoes que serao atualizadas</param>
        /// <returns></returns>
        [HttpPut]

        public IActionResult PutAtualizarIdUrl(int id, GeneroDomain genero)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

                if (generoBuscado != null)
                {
                    try
                    {
                        _generoRepository.AtualizarIdUrl(id, genero);

                        return StatusCode(200);
                    }
                    catch (Exception erro)
                    {

                        return BadRequest(erro.Message);
                    }
                }

                return NotFound("Nenhum Genero foi encontrado");
            }

            catch (Exception erro)
            {
                //Retorna com status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }



        /// <summary>
        /// Atualizar genero a partir do corpo
        /// </summary>
        /// <param name="genero">Objeto com as informacoes que serao atualizadas</param>
        /// <returns></returns>
        [HttpPut("{genero}")]

        public IActionResult PutAtualizarIdCorpo(GeneroDomain genero)
        {
            try
            {
                _generoRepository.AtualizarIdCorpo(genero);

                return StatusCode(200);
            }

            catch (Exception erro)
            {
                //Retorna com status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }
    }
}
