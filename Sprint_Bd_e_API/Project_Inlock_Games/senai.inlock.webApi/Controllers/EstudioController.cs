using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System.Data;

namespace senai.inlock.webApi_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //Define que o tipo de resposta da API sera no formato JSON
    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {

        private IEstudiosRepository _estudioRepository { get; set; }


        public EstudioController()
        {
            _estudioRepository = new EstudiosRepository();
        }


        /// <summary>
        /// EndPoint que aciona o metodo ListarTodos no repositorio e retorna a resposta para o usuario(Front-End)
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public IActionResult GetListarTodosEstudios()
        {
            try
            {
                List<EstudiosDomain>
                    listaEstudios = _estudioRepository.ListarTodosEstudios();


                return StatusCode(200, listaEstudios);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }



        /// <summary>
        /// EndPoint que aciona o metodo de cadastro de estudio
        /// </summary>
        /// <param name="novoEstudio">Objeto recebido para requisicao</param>
        /// <returns>status code 201(Created)</returns>
        [HttpPost]
        [Authorize(Roles = "2")]

        public IActionResult PostCadastrar(EstudiosDomain novoEstudio)
        {

            try
            {
                //Fazendo a chamada para o metodo cadastrar passando o objeto como parametro
                _estudioRepository.Cadastrar(novoEstudio);

                return StatusCode(201);

            }
            catch (Exception erro)
            {
                //Retorna com status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// EndPoint que aciona o metodo de deletar estudio
        /// </summary>
        /// <param name="id">Id do estudio a ser deletado</param>
        /// <returns>Status Code</returns>
        [HttpDelete("{@Id}")]
        [Authorize(Roles = "2")]

        public IActionResult DeleteDeletar(int id)
        {
            try
            {
                _estudioRepository.Deletar(id);
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
                EstudiosDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

                if (estudioBuscado == null)
                {
                    return NotFound("Nenhum Estudio foi encontrado");
                }

                return Ok(estudioBuscado);
            }
            catch (Exception erro)
            {
                //Retorna com status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }


    }
}
