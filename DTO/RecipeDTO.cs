namespace calculadora_custos.DTO;

public class InputRecipeFromDto
{
    public string? Name { get; set; }
    public decimal SellPrice { get; set; }
    public List<int> Ingredients { get; set; }
    public List<decimal> IngredientsAmount { get; set; }
}
