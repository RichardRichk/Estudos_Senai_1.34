using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.manha.Domains
{

    [Table(nameof(PresencasEvento))]
    public class PresencasEvento
    {
        [Key]
        public Guid IdPresencaEvento { get; set; } = Guid.NewGuid();


        [Column(TypeName ="BIT")]
        [Required(ErrorMessage ="Situacao obrigatoria")]
        public bool Situacao { get; set; }



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
