using calculadora_custos.Models;
using calculadora_custos.DTO;
namespace calculadora_custos.Repository;
    public interface IIngredientsToRecipe{
        List<Ingredient> GetIngredientsToRecipe();
        Ingredient CreateIngredientsToRecipe(Ingredient ingredientsToRecipe);
        void DeleteIngredientsToRecipe(int id);
        void UpdateIngredientsToRecipe(int id, Ingredient ingredientsToRecipe);
        bool IngredientsToRecipeExists(int id);
    }