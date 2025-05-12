using calculadora_custos.Models;
namespace calculadora_custos.Repository;
    public interface IIngredientsToRecipe{
        List<IngredientToRecipe> GetIngredientsToRecipe();
        IngredientToRecipe CreateIngredientsToRecipe(int recipeId, int ingredientId);
    }