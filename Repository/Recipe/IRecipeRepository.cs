using calculadora_custos.DTO;
using calculadora_custos.Models;
using calculadora_custos.Results;

namespace calculadora_custos.Repository;
public interface IRecipeRepository
{
    Task<List<Recipe>> GetRecipes();
    Task<Result<Recipe>> GetRecipeById(string id);
    Task<Result<Recipe>> CreateRecipe(InputRecipeFromDto recipe);
    Task<Result<Recipe>> DeleteRecipe(string id);
    Task<Result<Recipe>> UpdateRecipe(string id,InputRecipeFromDto recipe);
    List<IngredientReturnedByRecipeIdDto> IngredientsReturnedByRecipeId(int RecipeId);
}