using System.ComponentModel.DataAnnotations.Schema;

namespace ToroChallenge.Domain.Entities
{
    public class PatrimonioAtivos
    {
        [Column("patrimonio_id")]
        public int PatrimonioId { get; set; }
        public virtual Patrimonio Patrimonio { get; set; }

        [Column("ativo_id")]
        public int AtivoId { get; set; }
        public virtual Ativo Ativo { get; set; }

        [Column("quantidade_ativos")]
        public int QuantidadeAtivos { get; set; }
    }
}
