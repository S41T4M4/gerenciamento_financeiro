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

        [ForeignKey("Categoria")]
        public int id_categoria { get; set; }

        public virtual Categorias Categoria { get; set; }


        [ForeignKey("id_conta")]
        public int id_conta { get; set; }
       


    }
}
