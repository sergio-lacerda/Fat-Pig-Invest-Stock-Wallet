﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fat_Pig_Invest_Stock_Wallet.Models
{
    public enum TipoOrdem
    {
        Compra = 'C',
        Venda = 'V'
    }

    [Table("Ordens")]
    public class Ordem
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nota de negociação")]
        [Required(ErrorMessage = "O número da nota de negociação é obrigatório!")]
        public int NotaId { get; set; }
        public Nota Nota { get; set; }

        [Display(Name = "Data da ordem")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "A data da ordem é obrigatória!")]
        public DateTime DataHora { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "O tipo da ordem é obrigatório!")]
        [EnumDataType(typeof(TipoOrdem))]
        public char TipoOrdem { get; set; }

        [Display(Name = "Ação")]
        [Required(ErrorMessage = "O código da ação é obrigatório!")]
        public int AcaoId { get; set; }
        public Acao Acao { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória!")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser um valor positivo!")]
        public int Quantidade { get; set; }

        [Display(Name = "Preço unitário")]
        [Required(ErrorMessage = "O preço unitário é obrigatório!")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser um valor positivo!")]
        public double PrecoUnitario { get; set; }
    }
}