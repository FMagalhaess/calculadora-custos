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
            EnsureFields.EnsureNameNotNull(ingredient.Name!);
            EnsureFields.EnsureMeasureUnitNotNull(ingredient.MeasurementUnit!);
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


    public void UpdateIngredient(string id, Ingredient ingredient)
    {
        try
        {
            int.TryParse(id, out int idToSearch);
            ingredient.Id = idToSearch;
            if(IngredientExists(idToSearch))
            {
                _context.Ingredients.Update(ingredient);
                _context.SaveChanges();
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public bool IngredientExists(int id)
    {
        return _context.Ingredients.Any(i => i.Id == id);
    }
}