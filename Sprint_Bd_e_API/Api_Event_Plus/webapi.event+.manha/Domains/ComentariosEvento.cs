using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.manha.Domains
{

    [Table(nameof(ComentariosEvento))]
    public class ComentariosEvento
    {

        [Key]
        public Guid IdComentariosEvento { get; set; } = Guid.NewGuid();


        [Column(TypeName ="TEXT")]
        [Required(ErrorMessage = "A descricao e obrigatoria!")]
        public string? Descricao { get; set; }


        [Column(TypeName ="BIT")]
        [Required(ErrorMessage ="A informacao de exibicao e obrigatoria!")]
        public bool Exibe { get; set; }



        //ref. table Usuario = FX
        [Required(ErrorMessage = "Usuario obrigatorio!")]
        public Guid IdUsuario { get; set; }


        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }



        //ref. table Eventos = FX
        [Required(ErrorMessage = "Evento obrigatorio!")]
        public Guid IdEvento { get; set; }


        [ForeignKey(nameof(IdEvento))]
        public Evento? Evento { get; set; }
    }
}
