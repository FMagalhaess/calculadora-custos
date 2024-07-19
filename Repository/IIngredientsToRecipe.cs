using calculadora_custos.Models;
using calculadora_custos.DTO;
namespace calculadora_custos.Repository;
    public interface IIngredientsToRecipe{
        List<IngredientToRecipe> GetIngredientsToRecipe();
        IngredientToRecipe CreateIngredientsToRecipe(int RecipeId, int IngredientId);
        IngredientToRecipe CreateInstanceOfIngredientsToRecipe(int RecipeId, int IngredientId);
        void DeleteIngredientsToRecipe(int id);
        void UpdateIngredientsToRecipe(int id, IngredientToRecipe ingredientsToRecipe);
        bool IngredientsToRecipeExists(int id);
    }