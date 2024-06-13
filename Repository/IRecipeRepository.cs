using calculadora_custos.DTO;
using calculadora_custos.Models;
namespace calculadora_custos.Repository;
public interface IRecipeRepository
{
    List<Recipe> GetRecipes();
    Recipe CreateRecipe(InputRecipeFromDTO recipe);
}