using calculadora_custos.Models;
using calculadora_custos.DTO;
using System.Collections.Generic;
using calculadora_custos.Enums;
using calculadora_custos.Results;
using calculadora_custos.Services;

namespace calculadora_custos.Repository;

public class CostToRecipeRepository(
    IDbContext context,
    IIngredientRepository ingredientRepository) : ICostToRecipe
{
    public Result<CostToRecipe> Create(int recipeId, int costId,  Guid userId, int costType, decimal quantity)
    {
        var costExist = CostExist(costId, costType);
        if (costExist.IsSuccess == false)
        {
            return Result<CostToRecipe>.Fail(costExist.Error);
        }

        CostToRecipe costToRecipe = new()
        {
            CostType = costType,
            CostId = costId,
            RecipeId = recipeId,
            UserId = userId,
            Quantity = quantity
        };
        context.CostsToRecipe.Add(costToRecipe);
        context.SaveChanges();
        return Result<CostToRecipe>.Ok(costToRecipe);
    }

    private Result<bool> CostExist(int costId, int costType)
    {
        return costType switch
        {
            (int)CostType.Ingredient => context.Ingredients.Any(i => i.Id == costId)
                ? Result<bool>.Ok(true)
                : Result<bool>.Fail($"Ingredient: " + costId + " doesn't exist"),
            (int)CostType.Variable => context.VariableCost.Any(i => i.Id == costId)
                ? Result<bool>.Ok(true)
                : Result<bool>.Fail("VariableCost doesn't exist"),
            (int)CostType.Fixed => context.FixedCosts.Any(i => i.Id == costId)
                ? Result<bool>.Ok(true)
                : Result<bool>.Fail("FixedCost doesn't exist"),
            _ => Result<bool>.Fail("error at costType check in database")
        };
    }

}