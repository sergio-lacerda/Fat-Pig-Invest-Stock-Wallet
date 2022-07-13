using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fat_Pig_Invest_Stock_Wallet.Models
{
    [Table("Acoes")]
    public class Acao
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O código da ação é obrigatório!")]
        [StringLength(10, ErrorMessage = "O código da ação deve possuir no máximo 10 caracteres!")]
        public string Ticker { get; set; }

        [Display(Name = "Empresa")]
        [Required(ErrorMessage = "O nome da empresa é obrigatório!")]
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}
