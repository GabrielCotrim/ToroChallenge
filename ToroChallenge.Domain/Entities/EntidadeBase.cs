using System.ComponentModel.DataAnnotations.Schema;

namespace ToroChallenge.Domain.Entities
{
    public abstract class EntidadeBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id")]
        public int Id { get; set; }
    }
}
