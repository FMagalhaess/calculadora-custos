using calculadora_custos.Models;
using calculadora_custos.Results;
using calculadora_custos.Services;

namespace calculadora_custos.Repository.FixedCosts;

public class FixedCostsRepository(IDbContext context) : IFixedCostsRepository
{
    public Result<List<FixedCost>> GetFixedCost()
    {
        return Result<List<FixedCost>>.Ok(context.FixedCosts.ToList());
    }

    public Result<FixedCost> CreateFixedCost(FixedCost fixedCost)
    {
        var validation = ValideFixedCost(fixedCost);
        if (validation.IsSuccess != true)
            return Result<FixedCost>.Fail(validation.Error);
        context.FixedCosts.Add(fixedCost);
        context.SaveChanges();
        return Result<FixedCost>.Ok(fixedCost);
    }

    private static Result<string> ValideFixedCost(FixedCost fixedCost)
    {
        return EnsureFields.RunValidations(
                EnsureFields.NotNullOrEmpty(fixedCost.Category!, "Category"),
                EnsureFields.NotNullOrEmpty(fixedCost.Name!, "Name"),
                EnsureFields.EnsureNotNegativeOrZero(fixedCost.Cost, "Cost"),
                EnsureFields.EnsureNotNegativeOrZero(fixedCost.MonthlyFrequency, "Monthly frequency")
            );
    }
}