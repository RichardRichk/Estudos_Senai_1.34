using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codeFirst.manha.Domains
{

    [Table("Jogos")]
    public class JogosDomain
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome de jogo e obrigatorio!")]
        public string Nome { get; set; }


        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descricao do jogo e obrigatorio")]
        public string Descricao { get; set; }


        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data de lancamento e obrigatoria!")]
        public DateTime DataLancamento { get; set; }


        //[Colum(TypeName = "DECIMAL(4,2)")]
        [Column(TypeName = "SMALLMONEY")]
        [Required(ErrorMessage = "O preco do jogo e obrigatorio!")]
        public Decimal Valor { get; set; }


        //Referencia da chave estrangeira (Tabela de estudio)
        [Required(ErrorMessage = "Informe o estudio que produziu o jogo")]
        public Guid IdEstudio { get; set; }


        [ForeignKey ("IdEstudio")]
        public EstudioDomain Estudio { get; set; }

    }
}
