using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToroChallenge.Domain.Entities
{
    public class Ativo : EntidadeBase
    {
        [Column("symbol")]
        public string Symbol { get; set; }

        [Column("current_price")]
        public double CurrentPrice { get; set; }
        public virtual ICollection<PatrimonioAtivos> PatrimonioAtivos { get; set; }
    }
}
