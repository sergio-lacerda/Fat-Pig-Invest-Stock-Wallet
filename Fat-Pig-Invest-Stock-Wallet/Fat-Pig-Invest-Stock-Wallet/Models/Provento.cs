using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fat_Pig_Invest_Stock_Wallet.Models
{
    [Table("Proventos")]
    public class Provento
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tipo de provento")]
        [Required(ErrorMessage = "O tipo de provento é obrigatório!")]
        public int TipoProventoId { get; set; }
        public TipoProvento? TipoProvento { get; set; }

        [Display(Name = "Ticker")]
        [Required(ErrorMessage = "O ticker é obrigatório!")]
        public int AcaoId { get; set; }
        public Acao? Acao { get; set; }

        [Display(Name = "Data do provento")]
        [Required(ErrorMessage = "A data do provento é obrigatória!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataProvento { get; set; }

        [Display(Name = "Valor do provento")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "O valor do provento é obrigatório!")]
        [Range(0, double.MaxValue, ErrorMessage = "O valor do provento deve ser positivo ou zero!")]
        public decimal ValorProvento { get; set; }
    }
}
