using calculadora_custos.Models;
using calculadora_custos.Services;

namespace calculadora_custos.Repository;

public class DeliveryCostToRecipeRepository : IDeliveryCostsToRecipe
{
    private readonly IDbContext _context;
    private readonly IDeliveryCostRepository _deliveryCostRepository;

        public DeliveryCostToRecipeRepository(IDbContext context, IDeliveryCostRepository deliveryCostRepository)
        {
            _context = context;
            _deliveryCostRepository = deliveryCostRepository;
        }
    
    public DeliveryToRecipe CreateInstanceOfDeliveryCostsToRecipe(int RecipeId, int DeliveryCostId)
    {
        DeliveryToRecipe deliveryCostsToRecipe = new()
        {
            RecipeId = RecipeId,
            DeliveryCostId = DeliveryCostId
        };
        return deliveryCostsToRecipe;
    }

    public DeliveryToRecipe CreateDeliveryCostsToRecipe(int RecipeId, int DeliveryCostId)
    {
        DeliveryToRecipe deliveryCostsToRecipe = CreateInstanceOfDeliveryCostsToRecipe(RecipeId, DeliveryCostId);
        try
        {
            if(!_deliveryCostRepository.DeliveryCostExists(deliveryCostsToRecipe.DeliveryCostId))
            {
                throw new Exception("Delivery cost not found");
            }
            _context.DeliveryToRecipes.Add(deliveryCostsToRecipe);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
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