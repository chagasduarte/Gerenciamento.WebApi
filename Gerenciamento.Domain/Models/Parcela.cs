namespace Gerenciamento.Domain.Models
{
    public class Parcela
    {
        public int Id { get; set; }
        public int DespesaId { get; set; }
        public decimal Valor { get; set; }
        public DateTime Vencimento { get; set; }

    }
}
