using System.ComponentModel.DataAnnotations.Schema;

namespace calculadora_custos.Models
{
    public class FixedCost
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? Category { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? Name { get; set; }
        
        [Column(TypeName = "decimal(19,4)")]
        public decimal Cost { get; set; }
        
        public int MonthlyFrequency { get; set; }
    }
}