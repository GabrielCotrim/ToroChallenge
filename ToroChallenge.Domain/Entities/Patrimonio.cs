using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToroChallenge.Domain.Entities
{
    public class Patrimonio : EntidadeBase
    {
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public double Saldo { get; set; }
        public int TotalAtivos { get; set; }
        public virtual ICollection<PatrimonioAtivos> PatrimonioAtivos { get; set; }
    }
}
