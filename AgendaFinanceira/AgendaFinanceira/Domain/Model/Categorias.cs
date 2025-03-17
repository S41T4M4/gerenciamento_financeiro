using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaFinanceira.Domain.Model
{
    [Table("categorias")]
    public class Categorias
    {
        [Key]
        public int id_categoria { get; set; }
        public string nome_categoria { get; set; }
    }
}
