using calculadora_custos.Models;
using calculadora_custos.Services;
namespace calculadora_custos.Repository;

public class PreparationCostRepository : IPreparationCostRepository
{
    private readonly IDbContext _context;
    public PreparationCostRepository(IDbContext context)
    {
        _context = context;
    }
    public PreparationCost CreatePreparationCost(PreparationCost preparationCost)
    {
        try
        {
            EnsureFields.EnsureNameNotNull(preparationCost.Name);
            EnsureFields.EnsureDefaultAmountNotNegative(preparationCost.DefaultAmount);
            EnsureFields.EnsureMeasureUnitNotNull(preparationCost.MeasurementUnit);
            EnsureFields.EnsureTotalValueNotNegative(preparationCost.TotalValue);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        var entityEntry = _context.PreparationCosts.Add(preparationCost);
        PreparationCost toReturn = entityEntry.Entity;
        _context.SaveChanges();
        return toReturn;
    }

    public void DeletePreparationCost(int id)
    {
        throw new NotImplementedException();
    }

    public List<PreparationCost> GetPreparationCost()
    {
        return _context.PreparationCosts.ToList();
    }

    public bool PreparationCostExists(int id)
    {
        return _context.PreparationCosts.Any(p => p.Id == id);
    }

    public void UpdatePreparationCost(int id, PreparationCost preparationCost)
    {
        throw new NotImplementedException();
    }
}