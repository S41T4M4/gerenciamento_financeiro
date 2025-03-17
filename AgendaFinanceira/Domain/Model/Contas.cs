using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaFinanceira.Domain.Model
{
    [Table("contas")]
    public class Contas
    {
        [Key]
        public int id_conta { get; set; }
        public string nome_conta { get; set; }
        public decimal saldo { get; set; }

    }
}
