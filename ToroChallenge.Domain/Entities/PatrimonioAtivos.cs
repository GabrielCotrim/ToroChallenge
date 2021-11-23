using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToroChallenge.Domain.Entities
{
    public class PatrimonioAtivos
    {
        public int PatrimonioId { get; set; }
        public virtual Patrimonio Patrimonio { get; set; }
        public int AtivoId { get; set; }
        public virtual Ativo Ativo { get; set; }
        public int QuantidadeAtivos { get; set; }
    }
}
