using System.ComponentModel.DataAnnotations;

namespace Gerenciamento.Domain.Models
{
    public class Entrada
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public int ContaId { get; set; }
        [Required]
        public int DiaDebito { get; set; }
        [Required]
        public int MesDebito { get; set; }
        [Required]
        public int AnoDebito { get; set; }
        [Required]
        public bool IsFixo { get; set; }
    }
}
