using calculadora_custos.Models;
using calculadora_custos.Services;

namespace calculadora_custos.Repository;

public class DeliveryCostToRecipeRepository : IDeliveryCostsToRecipe
{
    private readonly IDbContext _context;
    private readonly IDeliveryCostRepository _deliveryCostRepository;
    private readonly IRecipeRepository _recipeRepository;

        public DeliveryCostToRecipeRepository(IDbContext context, IDeliveryCostRepository deliveryCostRepository, IRecipeRepository recipeRepository)
        {
            _context = context;
            _deliveryCostRepository = deliveryCostRepository;
            _recipeRepository = recipeRepository;
        }

    public DeliveryToRecipe CreateDeliveryCostsToRecipe(DeliveryToRecipe deliveryCostsToRecipe)
    {
        try
        {
            if(!_deliveryCostRepository.DeliveryCostExists(deliveryCostsToRecipe.DeliveryCostId))
            {
                throw new Exception("Delivery cost not found");
            }
            if(!_recipeRepository.RecipeExists(deliveryCostsToRecipe.RecipeId))
            {
                throw new Exception("Recipe not found");
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        _context.DeliveryToRecipes.Add(deliveryCostsToRecipe);
        _context.SaveChanges();
        return deliveryCostsToRecipe;
    }

    public void DeleteDeliveryCostsToRecipe(int id)
    {
        throw new NotImplementedException();
    }

    public bool DeliveryCostsToRecipeExists(int id)
    {
        throw new NotImplementedException();
    }

    public List<DeliveryToRecipe> GetDeliveryCostsToRecipe()
    {
        return _context.DeliveryToRecipes.ToList();
    }

    public void UpdateDeliveryCostsToRecipe(int id, DeliveryToRecipe deliveryCostsToRecipe)
    {
        throw new NotImplementedException();
    }
}