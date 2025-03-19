using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AgendaFinanceira.Domain.Model
{
    [Table("categorias")]
    public class Categorias
    {
        [Key]
        public int id_categoria { get; set; }
        public string nome_categoria { get; set; }


        [JsonIgnore]
        public virtual ICollection<Despesas> Despesas { get; set; }
    }
}
