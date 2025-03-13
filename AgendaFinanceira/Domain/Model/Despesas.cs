using System.ComponentModel.DataAnnotations;

namespace AgendaFinanceira.Domain.Model
{
    public class Despesas
    {
        [Key]

        public int id_despesa { get; set; }

        public bool recorrente { get; set; }
        public decimal valor { get; set; }
        public string descricao { get; set; }


    }
}
