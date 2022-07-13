using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fat_Pig_Invest_Stock_Wallet.Models
{
    [Table("Empresas")]
    public class Empresa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da empresa é obrigatório!")]
        [StringLength(50, ErrorMessage = "O nome da empresa deve possuir no máximo 50 caracteres!")]
        public string Nome { get; set; }

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "O CNPJ da empresa é obrigatório!")]
        [RegularExpression(@"(^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$)", ErrorMessage = "Formato de CNPJ inválido")]
        public int Cnpj { get; set; }
    }
}
