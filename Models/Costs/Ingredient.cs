using System.ComponentModel.DataAnnotations.Schema;

namespace calculadora_custos.Models
{
    public class Ingredient : ISoftDeletable
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        
        [Column(TypeName = "varchar(100)")]
        public string? Name { get; set; }
        
        [Column(TypeName = "varchar(100)")]
        public string? MeasurementUnit { get; set; }
        
        [Column(TypeName = "decimal(19,4)")]
        public decimal TotalAmount { get; set; }
        
        [Column(TypeName = "decimal(19,4)")]
        public decimal TotalValue { get; set; }
        
        [Column(TypeName = "decimal(19,4)")]
        public decimal ValuePerAmount { get; set; }
        
        [Column(TypeName = "decimal(19,4)")]
        public decimal DefaultAmount { get; set; }
        
        public DateTime? DeletedAt { get; set; }
    }
}