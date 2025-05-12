using calculadora_custos.Models;
using calculadora_custos.Results;

namespace calculadora_custos.Repository.FixedCosts;

public interface IFixedCostsRepository
{
    Task<Result<List<FixedCost>>> GetAllFixedCost();
    Task<Result<FixedCost>> CreateFixedCost(FixedCost fixedCost);
    Task<Result<FixedCost>> UpdateFixedCost(string id, FixedCost fixedCost);
    Task<Result<FixedCost>> DeleteFixedCost(string id);
}