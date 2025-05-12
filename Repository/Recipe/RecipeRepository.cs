using calculadora_custos.DTO;
using calculadora_custos.Models;
using calculadora_custos.Results;
using calculadora_custos.Services;
namespace calculadora_custos.Repository;

public class RecipeRepository : IRecipeRepository
{
    private readonly IDbContext _context;
    private readonly IIngredientsToRecipe _ingredientsToRecipe;
    private Result<decimal> totalCosts;
    private decimal sellPrice;
    private decimal profitPercentage;

    public RecipeRepository(
        IDbContext context,
        IIngredientsToRecipe ingredientsToRecipe
        )
    {
        _context = context;
        _ingredientsToRecipe = ingredientsToRecipe;
    }
    public Result<Recipe> CreateRecipe(InputRecipeFromDto recipe)
    {
        var validation = ValideRecipeCreation(recipe);
        if (!validation.IsSuccess)
            return Result<Recipe>.Fail(validation.Error);
        totalCosts = CalculateIngredientCost(recipe);
        if (!totalCosts.IsSuccess)
            return Result<Recipe>.Fail(totalCosts.Error);
        if(recipe.SellPrice > 0)
            profitPercentage = CalculateProfitPercentage(totalCosts.Data, recipe.SellPrice);

        var toReturn = new Recipe
        {
            Name = recipe.Name,
            Cost = totalCosts.Data,
            SellPrice = recipe.SellPrice,
            ProfitPercentage = profitPercentage,
            Profit = recipe.SellPrice - totalCosts.Data
        };
        return Result<Recipe>.Ok(toReturn);
    }

    private static Result<string> ValideRecipeCreation(InputRecipeFromDto recipe)
    {
        return EnsureFields.RunValidations(
            EnsureFields.NotNullOrEmpty(recipe.Name!, "Name"),
            EnsureFields.EnsureListNotNullOrEmpty(recipe.Ingredients!, "Ingredients"),
            EnsureFields.EnsureListNotNullOrEmpty(recipe.IngredientsAmount!, "IngredientsAmount"),
            EnsureFields.CheckIfItemListsAreEqualRr(recipe.Ingredients!, recipe.IngredientsAmount!)
            );
    }

    private Result<decimal> CalculateIngredientCost(InputRecipeFromDto recipe)
    {
        decimal totalCost = 0;
        foreach (var ingredient in recipe.Ingredients!)
        {
            if (!_context.Ingredients.Any(i => i.Id == ingredient))
                return Result<decimal>.Fail($"Ingredient {ingredient} not found");
            var findedIngredient = _context.Ingredients.FirstOrDefault(i => i.Id == ingredient);
            totalCost += (decimal)findedIngredient!.TotalValue * recipe.IngredientsAmount![recipe.Ingredients.IndexOf(ingredient)];
        }
        return Result<decimal>.Ok(totalCost);
    }
    public List<Recipe> GetRecipes()
    {
        var recipes = from recipe in _context.Recipes
                      select recipe;
        return _context.Recipes.ToList();
    }

    // public decimal CalculatePreparationCost(InputRecipeFromDTO recipe)
    // {
    //     decimal totalCost = 0;
    //     foreach (var preparation in recipe.PreparationCostItems!)
    //     {
    //         var findedPreparation = _context.PreparationCosts.FirstOrDefault(i => i.Id == preparation);
    //         totalCost += (decimal)findedPreparation!.TotalValue * recipe.PreparationCostItemsAmount![recipe.PreparationCostItems.IndexOf(preparation)];
    //     }
    //     return totalCost;
    // }

    // public decimal CalculatePresentationCost(InputRecipeFromDTO recipe)
    // {
    //     decimal totalCost = 0;
    //     foreach (var presentation in recipe.PresentationCostItems!)
    //     {
    //         var findedPresentation = _context.PresentationCosts.FirstOrDefault(i => i.Id == presentation);
    //         totalCost += (decimal)findedPresentation!.Value * recipe.PresentationCostItemsAmount![recipe.PresentationCostItems.IndexOf(presentation)];
    //     }
    //     return totalCost;
    // }

    // public decimal CalculateDeliveryCost(InputRecipeFromDTO recipe)
    // {
    //     decimal totalCost = 0;
    //     foreach (var delivery in recipe.DeliveryCostItems!)
    //     {
    //         var findedDelivery = _context.DeliveryCosts.FirstOrDefault(i => i.Id == delivery);
    //         totalCost += (decimal)findedDelivery!.Value * recipe.DeliveryCostItemsAmount![recipe.DeliveryCostItems.IndexOf(delivery)];
    //     }
    //     return totalCost;
    // }

    // public decimal CalculateTotalCost(InputRecipeFromDTO recipe)
    // {
    //     return CalculateIngredientCost(recipe) + CalculatePreparationCost(recipe) + CalculatePresentationCost(recipe) + CalculateDeliveryCost(recipe);
    // }
    public decimal CalculateProfitPercentage(decimal cost, decimal price)
    {
        decimal profit = price - cost;
        return (profit / price) * 100;
    }

    public bool RecipeExists(int id)
    {
        return _context.Recipes.Any(r => r.Id == id);
    }
    public List<IngredientReturnedByRecipeIdDto> IngredientsReturnedByRecipeId(int recipeId)
    {
        var ingredientsQuerry = from r in _context.Recipes
                        join ir in _context.IngredientToRecipes on r.Id equals ir.RecipeId
                        join i in _context.Ingredients on ir.IngredientId equals i.Id
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
    public Recipe GetRecipeById(int id)
    {
        if (!RecipeExists(id))
        {
            throw new Exception("Recipe not found");
        }
        return _context.Recipes.FirstOrDefault(r => r.Id == id);
    }
}