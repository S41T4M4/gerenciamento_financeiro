using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace AgendaFinanceira.Domain.Model
{
    [Table("receitas")]
    public class Receitas
    {
        [Key]
        public int id_receita { get; set; }

        public bool recorrente { get; set; }
        public decimal valor { get; set; }
        public string descricao { get; set; }

        // Definir o relacionamento com o modelo 'Conta'
        [ForeignKey("Contas")] // Usa o nome da propriedade de navegação "Conta"
        public int id_conta { get; set; }

        // A navegação explícita para o modelo relacionado
        public virtual Contas Contas { get; set; }
    }
}
