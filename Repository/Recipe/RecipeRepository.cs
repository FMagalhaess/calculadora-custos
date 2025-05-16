using calculadora_custos.DTO;
using calculadora_custos.Models;
using calculadora_custos.Results;
using calculadora_custos.Services;
using calculadora_custos.Services.Calculation;
using calculadora_custos.Services.Validation;
using Microsoft.EntityFrameworkCore;

namespace calculadora_custos.Repository;

public class RecipeRepository(
    IDbContext context,
    IValideInputs valideInputs,
    ICalculeItens calculeItens,
    IIngredientsToRecipe ingredientsToRecipe) : IRecipeRepository
{
    private Result<decimal> _totalCosts;
    private decimal _profitPercentage;
    public async Task<Result<Recipe>> CreateRecipe(InputRecipeFromDto recipe)
    {
        var validation = valideInputs.ValideRecipe(recipe);
        if (!validation.IsSuccess)
            return Result<Recipe>.Fail(validation.Error);
        
        _totalCosts = calculeItens.CalculateCosts(recipe.Ingredients, recipe.IngredientsAmount);
        if (!_totalCosts.IsSuccess)
            return Result<Recipe>.Fail(_totalCosts.Error);
        
        if(recipe.SellPrice > 0)
            _profitPercentage = calculeItens.CalculatePercentage(_totalCosts.Data, recipe.SellPrice).Data;

        var toReturn = new Recipe
        {
            Name = recipe.Name,
            Cost = _totalCosts.Data,
            SellPrice = recipe.SellPrice,
            ProfitPercentage = _profitPercentage,
            Profit = recipe.SellPrice - _totalCosts.Data
        };
        
        await context.Recipes.AddAsync(toReturn);
        await context.SaveChangesAsync();
        
        return Result<Recipe>.Ok(toReturn);
    }
    public async Task<List<Recipe>> GetRecipes()
    {
        return await context.Recipes.ToListAsync();
    }

    public async Task<Result<Recipe>> DeleteRecipe(string id)
    {
        if(!int.TryParse(id, out int recipeId))
            return Result<Recipe>.Fail($"Invalid id: {id}");
        var found = await context.Recipes.FindAsync(recipeId);
        if (found == null)
            return Result<Recipe>.Fail("Recipe not found");
        context.Recipes.Remove(found);
        await context.SaveChangesAsync();
        return Result<Recipe>.Ok(found);
    }

    public async Task<Result<Recipe>> UpdateRecipe(string id, InputRecipeFromDto recipe)
    {
        var validation = valideInputs.ValideRecipe(recipe);
        if (!validation.IsSuccess)
            return Result<Recipe>.Fail(validation.Error);
        
        if(!int.TryParse(id, out int recipeId))
            return Result<Recipe>.Fail("Invalid id");
        
        _totalCosts = calculeItens.CalculateCosts(recipe.Ingredients, recipe.IngredientsAmount);
        if (!_totalCosts.IsSuccess)
            return Result<Recipe>.Fail(_totalCosts.Error);
        
        if(recipe.SellPrice > 0)
            _profitPercentage = calculeItens.CalculatePercentage(_totalCosts.Data, recipe.SellPrice).Data;
        var dbRecipe = await context.Recipes.FindAsync(recipeId);
        if (dbRecipe == null)
            return Result<Recipe>.Fail("Recipe not found");
        dbRecipe.Name = recipe.Name;
        dbRecipe.SellPrice = recipe.SellPrice;
        dbRecipe.ProfitPercentage = _profitPercentage;
        dbRecipe.Profit = recipe.SellPrice - _totalCosts.Data;
        dbRecipe.Cost = _totalCosts.Data;
        context.Recipes.Update(dbRecipe);
        await context.SaveChangesAsync();
        return Result<Recipe>.Ok(dbRecipe);
    }
    
    public List<IngredientReturnedByRecipeIdDto> IngredientsReturnedByRecipeId(int recipeId)
    {
        var ingredientsQuerry = from r in context.Recipes
                        join ir in context.IngredientToRecipes on r.Id equals ir.RecipeId
                        join i in context.Ingredients on ir.IngredientId equals i.Id
                        where r.Id == recipeId
                        select new IngredientReturnedByRecipeIdDto
                        {
                            Id = i.Id,
                            RecipeName = r.Name,
                            IngredientName = i.Name,
                        };
        var toReturn = ingredientsQuerry.ToList();

        return toReturn;
    }
    public async Task<Result<Recipe>> GetRecipeById(string id)
    {
        if (!int.TryParse(id, out var recipeId))
            return Result<Recipe>.Fail($"Parse failed: {id}");
        var foundedRecipe = await context.Recipes.FindAsync(recipeId);
        if (foundedRecipe == null)
            return Result<Recipe>.Fail($"Recipe {id} not found");
        return Result<Recipe>.Ok(foundedRecipe);
    }
}