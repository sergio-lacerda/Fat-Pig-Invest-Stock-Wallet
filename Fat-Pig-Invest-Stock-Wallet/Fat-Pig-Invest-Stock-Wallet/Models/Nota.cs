using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fat_Pig_Invest_Stock_Wallet.Models
{
    [Table("Notas")]
    public class Nota
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Corretora")]
        [Required(ErrorMessage = "O nome da corretora é obrigatório!")]
        public int CorretoraId { get; set; }
        public Corretora? Corretora { get; set; }

        [Display(Name = "Número da nota")]
        [Required(ErrorMessage = "O número da nota é obrigatório!")]
        [Range(1, int.MaxValue, ErrorMessage = "O número da nota deve ser maior ou igual a 1!")]
        public int NumeroNota { get; set; }

        [Display(Name = "Data do pregão")]
        [Required(ErrorMessage = "A data do pregão é obrigatória!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataPregao { get; set; }
        
        [Display(Name = "Taxa de liquidação")]        
        [DisplayFormat(DataFormatString = "{0:c}")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "O valor da taxa é obrigatório!")]
        [Range(0, double.MaxValue, ErrorMessage = "O valor da taxa deve ser positivo ou zero!")]
        public decimal TaxaLiquidacao { get; set; }

        [Display(Name = "Emolumentos")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "O valor dos emolumentos é obrigatório!")]
        [Range(0, double.MaxValue, ErrorMessage = "O valor dos emolumentos deve ser positivo ou zero!")]
        public decimal Emolumentos { get; set; }

        [Display(Name = "Corretagem / Despesas")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "O valor da corretagem é obrigatório!")]
        [Range(0, double.MaxValue, ErrorMessage = "O valor da corretagem deve ser positivo ou zero!")]
        public decimal Corretagem { get; set; }

        [Display(Name = "Ordens")]
        public IEnumerable<Ordem>? Ordens { get; set; }
    }
}
