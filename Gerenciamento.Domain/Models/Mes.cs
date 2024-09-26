namespace Gerenciamento.Domain.Models
{
    public class Mes
    {
        public int Id { get; set; }
        public string NomeAbrev { get; set; }
        public decimal Entrada { get; set; }
        public decimal Saida { get; set; }
        public decimal Progressao { get; set; }
    }
}
