using calculadora_custos.Enums;
using calculadora_custos.Models;
using calculadora_custos.Results;

namespace calculadora_custos.Repository;
    public interface ICostToRecipe{
        // List<IngredientToRecipe> GetIngredientsToRecipe();
        Result<CostToRecipe> Create(int recipeId, int ingredientId, Guid userId, int costType, decimal quantity);
    }