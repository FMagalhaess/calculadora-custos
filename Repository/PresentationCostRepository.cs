using calculadora_custos.Models;
using calculadora_custos.Services;
namespace calculadora_custos.Repository;

public class PresentationCostRepository : IPresentationCostRepository
{
    private readonly IDbContext _context;
    public PresentationCostRepository(IDbContext context)
    {
        _context = context;
    }
    public PresentationCost CreatePresentationCost(PresentationCost presentationCost)
    {
        try
        {
            EnsureFields.EnsureNameNotNull(presentationCost.Name);
            EnsureFields.EnsureTotalAmountNotNegative(presentationCost.Amount);
            EnsureFields.EnsureTotalValueNotNegative(presentationCost.Value);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        var entityEntry = _context.PresentationCosts.Add(presentationCost);
        PresentationCost toReturn = entityEntry.Entity;
        _context.SaveChanges();
        return toReturn;
    }

    public void DeletePresentationCost(int id)
    {
        throw new NotImplementedException();
    }

    public List<PresentationCost> GetPresentationCost()
    {
        return _context.PresentationCosts.ToList();
    }

    public void UpdatePresentationCost(int id, PresentationCost presentationCost)
    {
        throw new NotImplementedException();
    }
}