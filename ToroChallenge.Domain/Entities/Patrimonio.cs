using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToroChallenge.Domain.Entities
{
    public class Patrimonio : EntidadeBase
    {
        [Column("usuario_id")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [Column("saldo")]
        public double Saldo { get; set; }

        [Column("total_ativos")]
        public int TotalAtivos { get; set; }
        public virtual ICollection<PatrimonioAtivos> PatrimonioAtivos { get; set; }
    }
}
