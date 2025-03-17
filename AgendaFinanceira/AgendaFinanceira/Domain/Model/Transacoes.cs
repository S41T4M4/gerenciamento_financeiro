using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaFinanceira.Domain.Model
{
    [Table("transacoes")]
    public class Transacoes
    {
        [Key]
        public int id_transacao { get; set; }

        public string tipo { get; set; }

        public decimal valor { get; set; }

        [JsonProperty("dataTransacao")]
        public DateTime data_transacao { get; set; }


        [ForeignKey("Contas")]
        [JsonProperty("idConta")]
        public int id_conta { get; set; }

        [ForeignKey("Categorias")]
        [JsonProperty("idCategoria")]
        public int id_categoria { get; set; }


        public virtual Contas Contas { get; set; }

        public virtual Categorias Categorias { get; set; }
    }
}
