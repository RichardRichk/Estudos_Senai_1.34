using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codeFirst.manha.Domains
{

    [Table("Estudio")]
    public class EstudioDomain
    {

        [Key]
        public Guid IdEstudio { get; set; } = Guid.NewGuid();


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome de estudio obrigatorio!")]
        public string Nome { get; set; }


        public List<JogosDomain> Jogos { get; set; }
    }
}
