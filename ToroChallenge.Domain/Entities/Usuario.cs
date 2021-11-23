using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToroChallenge.Domain.Entities
{
    public class Usuario : EntidadeBase
    {
        public string Apelido { get; set; }
    }
}
