using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fat_Pig_Invest_Stock_Wallet.Models
{
    [Table("TiposProvento")]
    public class TipoProvento
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do tipo de provento é obrigatório!")]
        [StringLength(50, ErrorMessage = "O nome do tipo de provento deve possuir no máximo 50 caracteres!")]
        public string Nome { get; set; }
    }
}
