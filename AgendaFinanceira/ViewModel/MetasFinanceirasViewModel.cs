namespace AgendaFinanceira.ViewModel
{
    public class MetasFinanceirasViewModel
    {
        public int IdMeta { get; set; }
        public string Descricao { get; set; }
        public decimal ValorMeta { get; set; }
        public decimal ValorAtual { get; set; }
        public DateTime Prazo { get; set; }
    }
}
