using calculadora_custos.Models;
using calculadora_custos.DTO;
using System.Collections.Generic;
using calculadora_custos.Services;

namespace calculadora_custos.Repository;

public class IngredientRepository : IIngredientRepository
{
    private readonly IDbContext _context;
    public IngredientRepository(IDbContext context)
    {
        _context = context;
    }
    public List<Ingredient> GetIngredients()
    {
        return _context.Ingredients.ToList();
    }

    public Ingredient CreateIngredient(Ingredient ingredient)
    {
        try
        {
            EnsureFields.EnsureNameNotNull(ingredient.Name);
            EnsureFields.EnsureMeasureUnitNotNull(ingredient.MeasurementUnit);
            EnsureFields.EnsureTotalAmountNotNegative(ingredient.TotalAmount);
            EnsureFields.EnsureTotalValueNotNegative(ingredient.TotalValue);
            EnsureFields.EnsureDefaultAmountNotNegative(ingredient.DefaultAmount);
            ingredient.ValuePerAmount = EnsureFields.DivedeTotalAmountByTotalValueToGetVPA(ingredient);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        _context.Ingredients.Add(ingredient);
        _context.SaveChanges();
        return ingredient;
        
    }


    public void DeleteIngredient(int id)
    {
        throw new NotImplementedException();
    }


    public void UpdateIngredient(int id, Ingredient ingredient)
    {
        throw new NotImplementedException();
    }
}