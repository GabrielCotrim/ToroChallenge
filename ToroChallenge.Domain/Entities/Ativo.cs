using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToroChallenge.Domain.Entities
{
    public class Ativo : EntidadeBase
    {
        public string Symbol { get; set; }
        public double CurrentPrice { get; set; }
        public virtual ICollection<PatrimonioAtivos> PatrimonioAtivos { get; set; }
    }
}
