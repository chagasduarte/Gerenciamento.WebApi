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
        public int DiaCompra { get; set; }
        public int MesCompra { get; set; }
        public int AnoCompra { get; set; }
    }
}
