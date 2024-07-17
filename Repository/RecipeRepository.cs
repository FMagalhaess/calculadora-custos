using System.Security.Cryptography.X509Certificates;
using calculadora_custos.DTO;
using calculadora_custos.Models;
using calculadora_custos.Services;
namespace calculadora_custos.Repository;

public class RecipeRepository : IRecipeRepository
{
    private readonly IDbContext _context;
    private readonly IIngredientsToRecipe _ingredientsToRecipe;
    private readonly IPreparationToRecipe _preparationToRecipe;
    private readonly IPresentationToRecipe _presentationToRecipe;
    private readonly IDeliveryCostsToRecipe _deliveryCostsToRecipe;
    private decimal totalCosts;
    private decimal sellPrice;
    private decimal profitPercentage;

    public RecipeRepository(
        IDbContext context,
        IIngredientsToRecipe ingredientsToRecipe,
        IPreparationToRecipe preparationToRecipe,
        IPresentationToRecipe presentationToRecipe,
        IDeliveryCostsToRecipe deliveryCostsToRecipe)
    {
        _context = context;
        _ingredientsToRecipe = ingredientsToRecipe;
        _preparationToRecipe = preparationToRecipe;
        _presentationToRecipe = presentationToRecipe;
        _deliveryCostsToRecipe = deliveryCostsToRecipe;
    }
    public Recipe CreateRecipe(InputRecipeFromDTO recipe)
    {
        try 
        {
            EnsureFields.EnsureNameNotNull(recipe.Name!);
            EnsureFields.EnsureIngredientsListNotNull(recipe.Ingredients!);
            EnsureFields.EnsurePreparationListNotNull(recipe.PreparationCostItems!);
            EnsureFields.EnsurePresentationListNotNull(recipe.PresentationCostItems!);
            EnsureFields.EnsureDeliveryCostListNotNull(recipe.DeliveryCostItems!);
            totalCosts = CalculateTotalCost(recipe);
            sellPrice = recipe.SellPrice ?? totalCosts * 1.2m;
            profitPercentage = CalculateProfitPercentage(totalCosts, sellPrice);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        Recipe toReturn = new()
        {
            Id = 1,
            Name = "Name Placeholder",
            Cost = totalCosts,
            Price = sellPrice,
            Profit = sellPrice - totalCosts,
            ProfitPercentage = profitPercentage
        };
        return toReturn;
    }
    public decimal CalculateIngredientCost(InputRecipeFromDTO recipe)
    {
        decimal totalCost = 0;
        foreach (var ingredient in recipe.Ingredients!)
        {
            var findedIngredient = _context.Ingredients.FirstOrDefault(i => i.Id == ingredient);
            totalCost += (decimal)findedIngredient!.TotalValue * recipe.IngredientsAmount![recipe.Ingredients.IndexOf(ingredient)];
        }
        return totalCost;
    }
    public List<Recipe> GetRecipes()
    {
        var recipes = from recipe in _context.Recipes
                      select recipe;
        return _context.Recipes.ToList();
    }

    public decimal CalculatePreparationCost(InputRecipeFromDTO recipe)
    {
        decimal totalCost = 0;
        foreach (var preparation in recipe.PreparationCostItems!)
        {
            var findedPreparation = _context.PreparationCosts.FirstOrDefault(i => i.Id == preparation);
            totalCost += (decimal)findedPreparation!.TotalValue * recipe.PreparationCostItemsAmount![recipe.PreparationCostItems.IndexOf(preparation)];
        }
        return totalCost;
    }

    public decimal CalculatePresentationCost(InputRecipeFromDTO recipe)
    {
        decimal totalCost = 0;
        foreach (var presentation in recipe.PresentationCostItems!)
        {
            var findedPresentation = _context.PresentationCosts.FirstOrDefault(i => i.Id == presentation);
            totalCost += (decimal)findedPresentation!.Value * recipe.PresentationCostItemsAmount![recipe.PresentationCostItems.IndexOf(presentation)];
        }
        return totalCost;
    }

    public decimal CalculateDeliveryCost(InputRecipeFromDTO recipe)
    {
        decimal totalCost = 0;
        foreach (var delivery in recipe.DeliveryCostItems!)
        {
            var findedDelivery = _context.DeliveryCosts.FirstOrDefault(i => i.Id == delivery);
            totalCost += (decimal)findedDelivery!.Value * recipe.DeliveryCostItemsAmount![recipe.DeliveryCostItems.IndexOf(delivery)];
        }
        return totalCost;
    }

    public decimal CalculateTotalCost(InputRecipeFromDTO recipe)
    {
        return CalculateIngredientCost(recipe) + CalculatePreparationCost(recipe) + CalculatePresentationCost(recipe) + CalculateDeliveryCost(recipe);
    }
    public decimal CalculateProfitPercentage(decimal cost, decimal price)
    {
        decimal profit = price - cost;
        return (profit / price) * 100;
    }

    public bool RecipeExists(int id)
    {
        return _context.Recipes.Any(r => r.Id == id);
    }
}