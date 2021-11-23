using System.ComponentModel.DataAnnotations.Schema;

namespace ToroChallenge.Domain.Entities
{
    public class Usuario : EntidadeBase
    {
        [Column("apelido")]
        public string Apelido { get; set; }
    }
}
