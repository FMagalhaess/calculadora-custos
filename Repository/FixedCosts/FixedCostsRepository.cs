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