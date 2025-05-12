using calculadora_custos.DTO;
using calculadora_custos.Models;
using calculadora_custos.Results;

namespace calculadora_custos.Repository;
public interface IRecipeRepository
{
    List<Recipe> GetRecipes();
    Recipe GetRecipeById(int id);
    Result<Recipe> CreateRecipe(InputRecipeFromDto recipe);
    List<IngredientReturnedByRecipeIdDto> IngredientsReturnedByRecipeId(int RecipeId);
}