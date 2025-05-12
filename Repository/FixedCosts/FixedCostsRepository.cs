using calculadora_custos.Models;
using calculadora_custos.Results;
using calculadora_custos.Services;
using Microsoft.EntityFrameworkCore;

namespace calculadora_custos.Repository.FixedCosts;

public class FixedCostsRepository(IDbContext context) : IFixedCostsRepository
{
    public async Task<Result<List<FixedCost>>> GetAllFixedCost()
    {
        return Result<List<FixedCost>>.Ok(await context.FixedCosts.ToListAsync());
    }

    public async Task<Result<FixedCost>> CreateFixedCost(FixedCost fixedCost)
    {
        var validation = ValideFixedCost(fixedCost);
        if (validation.IsSuccess != true)
            return Result<FixedCost>.Fail(validation.Error);
        await context.FixedCosts.AddAsync(fixedCost);
        context.SaveChanges();
        return Result<FixedCost>.Ok(fixedCost);
    }

    public async Task<Result<FixedCost>> UpdateFixedCost(string id, FixedCost fixedCost)
    {
        if(!int.TryParse(id, out int fixedCostId))
           return Result<FixedCost>.Fail("conversion failed");
        if (!await FixedCostExists(fixedCostId))
            return Result<FixedCost>.Fail($"id {fixedCostId} not found");
        
        fixedCost.Id = fixedCostId;
        
        context.FixedCosts.Update(fixedCost);
        context.SaveChanges();
        
        return Result<FixedCost>.Ok(fixedCost);
    }
    
    public async Task<Result<FixedCost>> DeleteFixedCost(string id)
    {
        if(!int.TryParse(id, out int fixedCostId))
            return Result<FixedCost>.Fail("conversion failed");
        
        var toDelete = await context.FixedCosts.FindAsync(fixedCostId);
        if(toDelete == null)
            return Result<FixedCost>.Fail($"id {fixedCostId} not found");
        
        context.FixedCosts.Remove(toDelete);
        context.SaveChanges();
        return Result<FixedCost>.Ok(toDelete);
    }

    private async Task<bool> FixedCostExists(int id)
    {
        return await context.FixedCosts.AnyAsync(fixedCost => fixedCost.Id == id);
    }

    private static Result<string> ValideFixedCost(FixedCost fixedCost)
    {
        return EnsureFields.RunValidations(
                EnsureFields.NotNullOrEmpty(fixedCost.Name!, "Name"),
                EnsureFields.NotNullOrEmpty(fixedCost.Category!, "Category"),
                EnsureFields.EnsureNotNegativeOrZero(fixedCost.Cost, "Cost"),
                EnsureFields.EnsureNotNegativeOrZero(fixedCost.MonthlyFrequency, "Monthly frequency")
            );
    }
}