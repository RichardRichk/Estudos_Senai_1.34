using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codeFirst.manha.Domains
{

    [Table("Usuario")]
    public class UsuarioDomain
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O email e obrigatorio!")]
        public string Email { get; set; }


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "A senha e obrigatoria!")]
        [StringLength(100, MinimumLength =6, ErrorMessage = "A senha deve conter de 6 a 100 caracteres")]
        public string Senha { get; set; }


        //Referencia da chave estrangeira (tabela de tiposusuario)
        [Required(ErrorMessage = "Tipo do usuario e obrigatorio!")]
        public Guid IdTipoUsuario { get; set; }


        [ForeignKey("IdTipoUsuario")]
        public TiposUsuarioDomain TipoUsuario { get; set; }

    }
}
