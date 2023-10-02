using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;
using webapi.event_.manha.Repositories;

namespace webapi.event_.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class InstituicaoController : ControllerBase
    {

        private IInstituicaoRepository _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        [HttpPost]
        public IActionResult Post(Instituicao instituicao)
        {
            try
            {
                if (instituicao != null)
                {
                    _instituicaoRepository.Cadastrar(instituicao);

                    return Ok("Usuario cadastrado!");

                }

                return Ok("Usuario não foi inserido corretamente!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
