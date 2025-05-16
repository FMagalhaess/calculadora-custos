using calculadora_custos.Models;
using calculadora_custos.Repository;
using calculadora_custos.Results;

namespace calculadora_custos.Services.Calculation;

public class CalculeItens(IDbContext context) : ICalculeItens
{
    public Result<decimal> CalculateCosts(List<int> listOfItensId, List<decimal> listOfItensQuantity)
    {
        var allIngredients = context.Ingredients
            .Where(i => listOfItensId.Contains(i.Id))
            .ToDictionary(i => i.Id);
        if (allIngredients.Count != listOfItensId.Count)
            return Result<decimal>.Fail("Some ingredients not found");
        decimal totalCost = 0;
        for (int i = 0; i < listOfItensId.Count; i++)
        {
            var id = listOfItensId[i];
            var amount = listOfItensQuantity![i];
            var ingredient = allIngredients[id];

            totalCost += ingredient.TotalValue * amount;
        }
        return Result<decimal>.Ok(totalCost);
    }

    public Result<decimal> CalculatePercentage(decimal cost, decimal sellPrice)
    {
        var profit = sellPrice - cost;
        return Result<decimal>.Ok((profit / cost) * 100);
    }

    public Result<decimal> CalculteDefaultCost(Ingredient ingredient)
    {
        var defaultCost = (ingredient.TotalValue / ingredient.TotalAmount) * ingredient.DefaultAmount;
        return Result<decimal>.Ok(defaultCost);
    }
}