using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaFinanceira.Domain.Model
{
    [Table("despesas")]
    public class Despesas
    {
        [Key]

        public int id_despesa { get; set; }

        public bool recorrente { get; set; }
        public decimal valor { get; set; }
        public string descricao { get; set; }



        [ForeignKey("contas")]

        public int id_conta { get; set; }
        public Contas Conta { get; set; }


    }
}
