using Gerenciamento.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Gerenciamento.Domain.Models
{
    public class Despesa
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        public string? Descricao { get; set; }
        [Required]
        public TipoDespesa TipoDespesa { get; set; }
        [Required]
        public bool IsParcelada { get; set; }
        [Required]
        public decimal ValorTotal { get; set; }
        [Required]
        public decimal ValorPago { get; set; }
        [Required]
        public DateTime DataCompra { get; set; }
        [Required]
        public bool IsPaga { get; set; }

    }
}
