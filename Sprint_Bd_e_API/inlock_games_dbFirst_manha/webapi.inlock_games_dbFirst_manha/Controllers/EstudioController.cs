using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock_games_dbFirst_manha.Domains;
using webapi.inlock_games_dbFirst_manha.Interfaces;
using webapi.inlock_games_dbFirst_manha.Repositories;

namespace webapi.inlock_games_dbFirst_manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Produces("Application/json")]
    public class EstudioController : ControllerBase
    {

        private IEstudioRepository _estudioRepository { get; set; }


        public EstudioController() 
        { 
            _estudioRepository= new EstudioRepository();
        }


        [HttpGet]
        public IActionResult GetListar()
        {
            try
            {
                return Ok(_estudioRepository.Listar());
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }


        [HttpGet("ListarComJogos")]

        public IActionResult GetListarComJogos()
        {
            try
            {
                return Ok(_estudioRepository.ListarComJogos());
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }



        [HttpGet("{id}")]

        public IActionResult GetBuscarPorId(Guid id)
        {
            try
            {
                return Ok(_estudioRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }


        [HttpDelete("{id}")]

        public IActionResult DeleteDeletar(Guid id)
        {
            try
            {
                _estudioRepository.Deletar(id);

                return StatusCode(204);
                //return NoContent();
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }



        [HttpPost]

        public IActionResult PostCadastrar(Estudio estudio)
        {
            try
            {
                _estudioRepository.Cadastrar(estudio);

                return StatusCode(201);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }



        [HttpPut("{id}")]

        public IActionResult PutAtualizar(Guid id, Estudio estudio)
        {
            try
            {
                _estudioRepository.Atualizar(id, estudio);

                return NoContent();
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

    }
}
