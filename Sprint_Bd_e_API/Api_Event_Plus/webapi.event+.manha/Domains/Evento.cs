using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.manha.Domains
{

    [Table(nameof(Evento))]
    public class Evento
    {
        [Key]
        public Guid IdEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = ("DATE"))]
        [Required(ErrorMessage = " Data do Evento Obrigatorio")]
        public DateTime DataEvento { get; set; }

        [Column(TypeName = ("VARCHAR(100)"))]
        [Required(ErrorMessage = " Nome do Evento Obrigatorio")]
        public string? NomeEvento { get; set; }

        [Column(TypeName = ("TEXT"))]
        [Required(ErrorMessage = " Descricao do Evento Obrigatorio")]
        public string? Descricao { get; set; }

        //Referencia A foreign key 

        [Required(ErrorMessage = "Tipo do Evento Obrigatorio")]
        public Guid IdTipoEvento { get; set; }

        [ForeignKey(nameof(IdTipoEvento))]
        public TiposEvento? TipoEvento { get; set; }


        [Required(ErrorMessage = "Id Institucao Obrigatorio")]
        public Guid IdInstitucao { get; set; }

        [ForeignKey(nameof(IdInstitucao))]
        public Instituicao? Instituicao { get; set; }

    }
}
