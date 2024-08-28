namespace Gerenciamento.Domain.Models
{
    public class ParcelasRequest
    {
        public int idDespesa { get; set; }
        public int qtdParcelas { get; set; }
        public decimal valor { get; set; }
        public DateTime dataCompra { get; set; }
    }
}
