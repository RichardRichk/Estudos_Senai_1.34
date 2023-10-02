using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.manha.Domains
{
    public class UsuarioDomain
    {
        public int IdUser { get; set; }

        [Required(ErrorMessage = "O email do usuario e obrigatorio!")]
        public string Email { get; set; }


        [StringLength(50,MinimumLength = 3, ErrorMessage = "A senha deve ter de 3 a 50 caracteres!")]
        [Required(ErrorMessage = "A senha do usuario e obrigatorio!")]
        public string Senha { get; set; }


        [Required(ErrorMessage = "A permissao do usuario e obrigatorio!")]
        public string Permissao { get; set; }
    }
}
