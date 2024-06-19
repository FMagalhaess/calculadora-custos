using calculadora_custos.DTO;
using calculadora_custos.Models;
namespace calculadora_custos.Repository;
public interface IRecipeRepository
{
    List<Recipe> GetRecipes();
    Recipe CreateRecipe(InputRecipeFromDTO recipe);
    decimal CalculateIngredientCost(InputRecipeFromDTO recipe);
    decimal CalculatePreparationCost(InputRecipeFromDTO recipe);
    decimal CalculatePresentationCost(InputRecipeFromDTO recipe);
    decimal CalculateDeliveryCost(InputRecipeFromDTO recipe);
    decimal CalculateTotalCost(InputRecipeFromDTO recipe);
}