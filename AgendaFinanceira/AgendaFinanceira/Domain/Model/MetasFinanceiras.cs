using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaFinanceira.Domain.Model
{
    [Table("metas_financeiras")]
    public class MetasFinanceiras
    {
        [Key]
        public int id_meta { get; set; }
        public string descricao { get; set; }
        public decimal valor_meta { get; set; }
        public decimal valor_atual { get; set; }
        public DateTime prazo { get; set; }
    }
}
