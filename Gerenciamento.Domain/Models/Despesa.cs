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
        public bool IsFixa { get; set; }
        [Required]
        public decimal ValorTotal { get; set; }
        [Required]
        [Range(1,30)]
        public int DiaCompra { get; set; }
        [Required]
        [Range(1,12)]
        public int MesCompra { get; set; }
        [Required]
        [Range(2000,2050)]
        public int AnoCompra { get; set; }
        [Required]
        public bool Status { get; set; }

    }
}
