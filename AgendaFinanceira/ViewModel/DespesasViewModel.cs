namespace AgendaFinanceira.ViewModel
{
    public class DespesasViewModel
    {
        public int IdDespesas { get; set; }
        public bool Recorrente { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public int IdConta { get; set; }
    }
}
