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
    public class TipoUsuariosController : ControllerBase
    {

        private ITipoUsuariosRepository _tipoUsuariosRepository { get; set; }


        public TipoUsuariosController()
        {
            _tipoUsuariosRepository = new TipoUsuariosRepository();
        }


        /// <summary>
        /// EndPoint que aciona o metodo ListarTodos no repositorio e retorna a resposta para o usuario(Front-End)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "2")]

        public IActionResult GetListarTodos()
        {
            try
            {
                List<TipoUsuariosDomain> listaTipoUsuarios = _tipoUsuariosRepository.ListarTodos();


                return StatusCode(200, listaTipoUsuarios);

            }

            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }



        /// <summary>
        /// EndPoint que aciona o metodo de cadastro de Tipo de Usuario
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto recebido para requisicao</param>
        /// <returns>status code 201(Created)</returns>
        [HttpPost]
        [Authorize(Roles = "2")]

        public IActionResult PostCadastrar(TipoUsuariosDomain novoTipoUsuario)
        {

            try
            {
                //Fazendo a chamada para o metodo cadastrar passando o objeto como parametro
                _tipoUsuariosRepository.Cadastrar(novoTipoUsuario);

                return StatusCode(201);

            }
            catch (Exception erro)
            {
                //Retorna com status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// EndPoint que aciona o metodo de deletar Tipo usuario
        /// </summary>
        /// <param name="id">Id do tipo usuario a ser deletado</param>
        /// <returns>Status Code</returns>
        [HttpDelete("{@Id}")]
        [Authorize(Roles = "2")]
        public IActionResult DeleteDeletar(int id)
        {
            try
            {
                _tipoUsuariosRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


    }
}
