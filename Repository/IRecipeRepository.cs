using calculadora_custos.Models;
namespace calculadora_custos.Repository;
public interface IRecipeRepository
{
    Recipe GetRecipe();
    Recipe CreateRecipe(Recipe recipe);
}