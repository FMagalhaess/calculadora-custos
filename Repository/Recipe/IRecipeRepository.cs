using calculadora_custos.DTO;
using calculadora_custos.Models;
namespace calculadora_custos.Repository;
public interface IRecipeRepository
{
    List<Recipe> GetRecipes();
    Recipe GetRecipeById(int id);
    Recipe CreateRecipe(InputRecipeFromDTO recipe);
    decimal CalculateIngredientCost(InputRecipeFromDTO recipe);
    decimal CalculatePreparationCost(InputRecipeFromDTO recipe);
    decimal CalculatePresentationCost(InputRecipeFromDTO recipe);
    decimal CalculateDeliveryCost(InputRecipeFromDTO recipe);
    decimal CalculateTotalCost(InputRecipeFromDTO recipe);
    bool RecipeExists(int id);
    List<IngredientReturnedByRecipeIdDTO> IngredientsReturnedByRecipeId(int RecipeId);
    List<DeliveryCostReturnedByRecipeDTO> GetDeliveryCostsById(int recipeId);
    List<DeliveryCostReturnedByRecipeDTO> GetPreparationCostsById(int recipeId);
    List<DeliveryCostReturnedByRecipeDTO> GetPresentationCostsById(int recipeId);

}