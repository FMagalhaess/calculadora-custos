using calculadora_custos.Models;
using calculadora_custos.Services;

namespace calculadora_custos.Repository;

public class DeliveryCostToRecipe : IDeliveryCostsToRecipe
{
    private readonly IDbContext _context;

        public DeliveryCostToRecipe(IDbContext context)
        {
            _context = context;
        }

    public DeliveryCost CreateDeliveryCostsToRecipe(DeliveryCost deliveryCostsToRecipe)
    {
        throw new NotImplementedException();
    }

    public void DeleteDeliveryCostsToRecipe(int id)
    {
        throw new NotImplementedException();
    }

    public bool DeliveryCostsToRecipeExists(int id)
    {
        throw new NotImplementedException();
    }

    public List<DeliveryCost> GetDeliveryCostsToRecipe()
    {
        throw new NotImplementedException();
    }

    public void UpdateDeliveryCostsToRecipe(int id, DeliveryCost deliveryCostsToRecipe)
    {
        throw new NotImplementedException();
    }
}