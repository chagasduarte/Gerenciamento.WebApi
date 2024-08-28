using System.ComponentModel.DataAnnotations;

namespace Gerenciamento.Domain.Models
{
    public class Conta
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public decimal Credito { get; set; }
        [Required]
        public decimal Debito { get; set; }

    }
}
