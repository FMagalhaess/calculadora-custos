using System.ComponentModel.DataAnnotations.Schema;

namespace calculadora_custos.Models;

public class VariableCost
{
    public int Id { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string? Name { get; set; }
    [Column(TypeName = "decimal(19,4)")]
    public double? CostByKm { get; set; }
    [Column(TypeName = "decimal(19,4)")]
    public double? CostByHour { get; set; }
    [Column(TypeName = "decimal(19,4)")]
    public decimal? Cost { get; set; }
}