namespace Gerenciamento.Domain.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Credito { get; set; }
        public decimal Debito { get; set; }

    }
}
