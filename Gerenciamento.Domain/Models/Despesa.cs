using Gerenciamento.Domain.Enums;

namespace Gerenciamento.Domain.Models
{
    public class Despesa
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public TipoDespesa TipoDespesa { get; set; }
        public decimal ValorTotal { get; set; }
        public DateOnly DataCompra { get; set; }
        public List<Parcela>? Parcelas { get; set; }
    }
}
