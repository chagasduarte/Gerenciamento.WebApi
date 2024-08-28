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
        public int DiaVencimento { get; set; }
        [Required]
        public int MesVencimento { get; set; }
        [Required]
        public int AnoVencimento { get; set; }
        [Required]
        public int Status { get; set; }

        public Parcela(int despesaId, decimal valor, int diaVencimento, int mesVencimento, int anoVencimento, int status)
        {
            DespesaId = despesaId;
            Valor = valor;
            DiaVencimento = diaVencimento;
            MesVencimento = mesVencimento;
            AnoVencimento = anoVencimento;
            Status = status;
        }
    }
}
