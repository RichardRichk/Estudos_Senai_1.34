using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.manha.Domains;
using webapi.filmes.manha.Interfaces;
using webapi.filmes.manha.Repositories;

namespace webapi.filmes.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {

        /// <summary>
        /// Objeto _filmeRepository que ira receber todos os metodos definidos na interface IFilmeRepository
        /// </summary>
        private IFilmeRepository _filmeRepository { get; set; }


        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }


        /// <summary>
        /// EndPoint que aciona o metodo LitarTodos no repositorio e retorna a resposta para o usuario(Front-End)
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public IActionResult GetListarTodos()
        {
            try
            {
                List<FilmeDomain> listaFilmes = _filmeRepository.ListarTodos();

                return StatusCode(200, listaFilmes);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// EndPoint que aciona o metodo de cadastro de genero
        /// </summary>
        /// <param name="novoFilme">Objeto recebido para requisicao</param>
        /// <returns>Status Code 201(Created)</returns>
        [HttpPost]

        public IActionResult PostCadastrar(FilmeDomain novoFilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novoFilme);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// EndPoint que aciona o metodo de deletar genero
        /// </summary>
        /// <param name="id">id do filme a ser deletado</param>
        /// <returns>Status Code</returns>
        [HttpDelete("{@Id}")]

        public IActionResult DeleteDeletar(int id)
        {
            try
            {
                _filmeRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        [HttpGet("{id}")]

        public IActionResult GetBuscarPorId(int id)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

                if (filmeBuscado == null)
                {
                    return NotFound("Nenhum Filme foi encontrado");
                }

                return Ok(filmeBuscado);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        [HttpPut]

        public IActionResult PutAtualizarIdUrl(int id, FilmeDomain filme)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);
                if (filmeBuscado != null)
                {
                    try
                    {
                        _filmeRepository.AtualizarIdUrl(id, filme);

                        return StatusCode(200);
                    }
                    catch (Exception erro)
                    {

                        return BadRequest(erro.Message);
                    }
                }

                return NotFound("Nenhum filme foi encontrado!");
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        [HttpPut("{genero}")]

        public IActionResult PutAtualizarIdCorpo(FilmeDomain filme)
        {
            try
            {
                _filmeRepository.AtualizarIdCorpo(filme);

                return StatusCode(200);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
