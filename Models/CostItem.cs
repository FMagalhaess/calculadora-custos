using System.ComponentModel.DataAnnotations.Schema;
using calculadora_custos.Enums;

namespace calculadora_custos.Models;

public class CostItem
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public CostType ItemType { get; set; }
    
    [Column(TypeName = "varchar(100)")]
    public string? ItemName { get; set; }
    
    [Column(TypeName = "decimal(19,4)")]
    public decimal Cost { get; set; }
    
    [Column(TypeName = "varchar(300)")]
    public string? Description { get; set; }
}