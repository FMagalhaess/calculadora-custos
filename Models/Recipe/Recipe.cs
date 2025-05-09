using System.ComponentModel.DataAnnotations.Schema;

namespace calculadora_custos.Models;

public class Recipe
{
    public int Id { get; set; }
    
    [Column(TypeName = "varchar(100)")]
    public string? Name { get; set; }
    [Column(TypeName = "decimal(19,4)")]
    public decimal Cost { get; set; }
    [Column(TypeName = "decimal(19,4)")]
    public decimal SellPrice { get; set; }
    [Column(TypeName = "decimal(19,4)")]
    public decimal Profit { get; set; }
    public decimal ProfitPercentage { get; set; }
}