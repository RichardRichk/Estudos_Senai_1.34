using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.filmes.manha.Domains;
using webapi.filmes.manha.Interfaces;
using webapi.filmes.manha.Repositories;

namespace webapi.filmes.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {

        private IUsuarioRepository _usuarioRepository { get; set; }


        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        [HttpPost]

        public IActionResult PostLogin (UsuarioDomain usuarioLogin)
        {

            try
            {

                UsuarioDomain usuario = _usuarioRepository.Login(usuarioLogin.Email, usuarioLogin.Senha);

                if (usuario == null)
                {
                    return BadRequest("Usuario nao encontrado");
                }

                //Caso encontre o usuario , prossegue para a criacao do token.


                //1º Definir as informacoes(Claims) que serao fornecidos no token (PAYLOAD)
                var claims = new[]
                {

                    //Formato da claim 
                    new Claim(JwtRegisteredClaimNames.Jti,usuario.IdUser.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.Permissao)


                    //Existe a possibilidade de criar uma claim personalizada
                    //new Claim("Claim Personalizada", "Valor da Claim Personalizada")
                };


                //2º - Definir a chave de acesso do token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));


                //3º - Definir as credenciais do token(HEADER)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4º - Gerar token
                var token = new JwtSecurityToken
                    (
                        //Emissor do token
                        issuer: "webapi.filmes.manha", 

                        //Destinatario
                        audience: "webapi.filmes.manha",

                        //dados definidos nas claims(informacoes)
                        claims: claims,

                        //Tempo de expiracao do token
                        expires: DateTime.Now.AddMinutes(5),

                        //credenciais do token
                        signingCredentials: creds
                    );

                //5º - Retirnar o token criado
                return Ok(new 
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });


            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }       
        }
    }
}
