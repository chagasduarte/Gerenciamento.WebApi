namespace Gerenciamento.Domain.Models
{
    public class Parcela
    {
        public int Id { get; set; }
        public int DespesaId { get; set; }
        public decimal Valor { get; set; }
        public int DiaVencimento { get; set; }
        public int MesVencimento { get; set; }
        public int AnoVencimento { get; set; }

    }
}
