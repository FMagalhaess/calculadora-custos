using calculadora_custos.Models;
using calculadora_custos.Results;

namespace calculadora_custos.Repository.VariableCosts;

public interface IVariableCostsRepository
{
    Task<List<VariableCost>> GetAllVariableCosts();
    Task<Result<VariableCost>> CreateVariableCost(VariableCost variableCost);
    Task<Result<VariableCost>> Delete(string variableCostId);
}