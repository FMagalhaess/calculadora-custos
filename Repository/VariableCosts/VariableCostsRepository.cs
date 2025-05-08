using calculadora_custos.Models;
using calculadora_custos.Results;
using calculadora_custos.Services;
using Microsoft.EntityFrameworkCore;

namespace calculadora_custos.Repository.VariableCosts;

public class VariableCostsRepository(IDbContext context) : IVariableCostsRepository
{
    public async Task<List<VariableCost>> GetAllVariableCosts()
    {
        return await context.VariableCost.ToListAsync();
    }

    public async Task<Result<VariableCost>> CreateVariableCost(VariableCost variableCost)
    {
        var valideName = EnsureFields.NotNullOrEmpty(variableCost.Name!, "Name");
        if (!valideName.IsSuccess)
            return Result<VariableCost>.Fail(valideName.Error);
        
        var valideCosts = AtLeastOneGreaterThanZero(variableCost); 
        if (!valideCosts.IsSuccess)
            return Result<VariableCost>.Fail(valideCosts.Error);
        var dbVariableCost = await context.VariableCost.AddAsync(variableCost);
        context.SaveChanges();
        return Result<VariableCost>.Ok(dbVariableCost.Entity);
    }

    public async Task<Result<VariableCost>> Delete(string variableCostId)
    {
        if(!int.TryParse(variableCostId, out var valideCostId))
            return Result<VariableCost>.Fail("Id invalido");
        var finded = await context.VariableCost.FindAsync(valideCostId);
        if (finded == null)
            return Result<VariableCost>.Fail("Variable cost not found");
        context.VariableCost.Remove(finded);
        context.SaveChanges();
        return Result<VariableCost>.Ok(finded);
    }

    private static Result<string> AtLeastOneGreaterThanZero(VariableCost variableCost)
    {
        if (variableCost.CostByKm <= 0
            & variableCost.Cost <= 0
            & variableCost.CostByKm <= 0)
        {
            return Result<string>.Fail("At least one variable cost must be greater than zero");
        }

        return Result<string>.Ok("");
    }
}