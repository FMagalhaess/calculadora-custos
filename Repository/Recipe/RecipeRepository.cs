using calculadora_custos.DTO;
using calculadora_custos.Models;
using calculadora_custos.Results;
using calculadora_custos.Services;
using Microsoft.EntityFrameworkCore;

namespace calculadora_custos.Repository;

public class RecipeRepository(
    IDbContext context,
    IIngredientsToRecipe ingredientsToRecipe) : IRecipeRepository
{
    private Result<decimal> _totalCosts;
    private decimal _profitPercentage;
    public async Task<Result<Recipe>> CreateRecipe(InputRecipeFromDto recipe)
    {
        var validation = ValideRecipeCreation(recipe);
        if (!validation.IsSuccess)
            return Result<Recipe>.Fail(validation.Error);
        
        _totalCosts = CalculateIngredientCost(recipe);
        if (!_totalCosts.IsSuccess)
            return Result<Recipe>.Fail(_totalCosts.Error);
        
        if(recipe.SellPrice > 0)
            _profitPercentage = CalculateProfitPercentage(_totalCosts.Data, recipe.SellPrice);

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

    private static Result<string> ValideRecipeCreation(InputRecipeFromDto recipe)
    {
        return EnsureFields.RunValidations(
            EnsureFields.NotNullOrEmpty(recipe.Name!, "Name"),
            EnsureFields.EnsureListNotNullOrEmpty(recipe.Ingredients!, "Ingredients"),
            EnsureFields.EnsureListNotNullOrEmpty(recipe.IngredientsAmount!, "IngredientsAmount"),
            EnsureFields.CheckIfItemListsAreEqualRr(recipe.Ingredients!, recipe.IngredientsAmount!),
            EnsureFields.EnsureListDoesNotContainZeroOrNegative(recipe.Ingredients!, "ingredients"),
            EnsureFields.EnsureListDoesNotContainZeroOrNegative(recipe.IngredientsAmount!, "ingredientsAmount")
            );
    }

    private Result<decimal> CalculateIngredientCost(InputRecipeFromDto recipe)
    {
        decimal totalCost = 0;
        foreach (var ingredient in recipe.Ingredients!)
        {
            if (!context.Ingredients.Any(i => i.Id == ingredient))
                return Result<decimal>.Fail($"Ingredient {ingredient} not found");
            var findedIngredient = context.Ingredients.FirstOrDefault(i => i.Id == ingredient);
            totalCost += (decimal)findedIngredient!.TotalValue * recipe.IngredientsAmount![recipe.Ingredients.IndexOf(ingredient)];
        }
        return Result<decimal>.Ok(totalCost);
    }
    public async Task<List<Recipe>> GetRecipes()
    {
        return await context.Recipes.ToListAsync();
    }

    
    public decimal CalculateProfitPercentage(decimal cost, decimal price)
    {
        decimal profit = price - cost;
        return (profit / price) * 100;
    }

    public bool RecipeExists(int id)
    {
        return context.Recipes.Any(r => r.Id == id);
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
        if (int.TryParse(id, out var recipeId))
            return Result<Recipe>.Fail($"Parse failed: {id}");
        var foundedRecipe = await context.Recipes.FindAsync(recipeId);
        if (foundedRecipe == null)
            return Result<Recipe>.Fail($"Recipe {id} not found");
        return Result<Recipe>.Ok(foundedRecipe);
    }
}