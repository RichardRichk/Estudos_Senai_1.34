using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.manha.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {

        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do evento obrigatorio!")]
        public string? Nome { get; set; }


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Email do evento obrigatorio!")]
        public string? Email { get; set; }


        [Column(TypeName = "CHAR(60)")]
        [Required(ErrorMessage = "Senha do evento obrigatorio!")]
        [StringLength(60, MinimumLength =3, ErrorMessage = "A senha deve conter de 3 a 60 caracteres")]
        public string? Senha { get; set; }


        //ref.tabela TipoUsuario = FK
        [Required(ErrorMessage ="Informe o tipo usuario!")]
        public Guid IdTipoUsuario { get; set; }


        [ForeignKey(nameof(IdTipoUsuario))]
        public TiposUsuario? TipoUsuario { get; set; }

    }
}
