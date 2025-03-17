using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace interview.Models
{
    [Table("example")]
    public class Example
    {
        [Key]
        [Column("id")]
        public int? id { get; set; }
        [Column("name")]
        public string? name { get; set; }
    }
}
