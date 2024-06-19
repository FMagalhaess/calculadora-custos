using calculadora_custos.Models;
namespace calculadora_custos.DTO;

public class RecipeDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Cost { get; set; }
    public decimal Price { get; set; }
    public decimal Profit { get; set; }
    public decimal ProfitPercentage { get; set; }
}

public class InputRecipeFromDTO
{
    public string? Name { get; set; }
    public decimal? SellPrice { get; set; }
    public List<int>? Ingredients { get; set; }
    public List<decimal>? IngredientsAmount { get; set; }
    public List<int>? PreparationCostItems { get; set; }
    public List<decimal>? PreparationCostItemsAmount { get; set; }
    public List<int>? PresentationCostItems { get; set; }
    public List<decimal>? PresentationCostItemsAmount { get; set; }
    public List<int>? DeliveryCostItems { get; set; }
    public List<decimal>? DeliveryCostItemsAmount { get; set; }

}