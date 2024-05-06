using calculadora_custos.Models;
namespace calculadora_custos.DTO;

public class IngredientDto
{
    public string? Name { get; set; }
    public string? MeasurementUnit { get; set; }
    public double TotalAmount { get; set; }
    public double TotalValue { get; set; }
    public double ValuePerAmount { get; set; }
    public double DefaultAmount { get; set; }
}
public class IngredientFullFromDatabase
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? MeasurementUnit { get; set; }
    public double TotalAmount { get; set; }
    public double TotalValue { get; set; }
    public double ValuePerAmount { get; set; }
    public double DefaultAmount { get; set; }
}