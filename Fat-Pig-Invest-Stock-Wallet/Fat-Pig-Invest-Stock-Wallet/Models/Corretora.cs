using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fat_Pig_Invest_Stock_Wallet.Models
{
    [Table("Corretoras")]
    public class Corretora
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da corretora é obrigatório!")]
        [StringLength(50, ErrorMessage = "O nome da corretora deve possuir no máximo 50 caracteres!")]
        public string Nome { get; set; }
    }
}
