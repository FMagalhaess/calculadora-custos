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
        public double TotalAmount { get; set; }
        public double TotalValue { get; set; }
        public double ValuePerAmount { get; set; }
        public double DefaultAmount { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}