using System.ComponentModel.DataAnnotations;

namespace Gerenciamento.Domain.Models
{
    public class Parcela
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int DespesaId { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public DateTime DataVencimento { get; set; }
        [Required]
        public int IsPaga { get; set; }

    }
}
