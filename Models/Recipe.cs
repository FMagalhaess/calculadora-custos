namespace calculadora_custos.Models;

public class Recipe
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Cost { get; set; }
    public decimal Price { get; set; }
    public decimal Profit { get; set; }
    public decimal ProfitPercentage { get; set; }
}