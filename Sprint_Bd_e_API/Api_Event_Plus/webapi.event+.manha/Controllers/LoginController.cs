using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;
using webapi.event_.manha.Repositories;
using webapi.event_.manha.ViewModels;

namespace webapi.event_.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;


        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult PostLogin(LoginViewModel user)
        {
            try
            {
               Usuario usuarioBuscado = _usuarioRepository.BuscarPorCadastro(user.Email, user.Senha);

                if (usuarioBuscado == null)
                {
                    return StatusCode(401, "Email ou senha invalidos!");
                }



                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome!),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario!.Titulo!),
                };



                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("event-plus-chave-autenticacao-webapi-dev"));



                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);



                var token = new JwtSecurityToken
                    (
                        issuer: "Event+_Manha",

                        audience: "Event+_Manha",

                        claims: claims,

                        expires: DateTime.Now.AddMinutes(8),

                        signingCredentials: creds


                    );


                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
