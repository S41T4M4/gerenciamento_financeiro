namespace AgendaFinanceira.ViewModel
{
    public class TransacoesViewModel
    {
        public int IdTransacao { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataTransacao { get; set; }
        public int IdConta { get; set; }
        public int IdCategoria { get; set; }

    }
}
