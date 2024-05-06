using calculadora_custos.Models;
using calculadora_custos.DTO;
using System.Collections.Generic;

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
            EnsureNameNotNull(ingredient);
            EnsureMeasureUnitNotNull(ingredient);
            EnsureTotalAmountNotNegative(ingredient);
            EnsureTotalValueNotNegative(ingredient);
            EnsureDefaultAmountNotNegative(ingredient);
            ingredient.ValuePerAmount = DivedeTotalAmountByTotalValueToGetVPA(ingredient);
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
    public void EnsureNameNotNull(Ingredient ingredient)
    {
        if (ingredient.Name == null || ingredient.Name.Trim() == "")
        {
            throw new Exception("Name is required");
        }
    }
    public void EnsureMeasureUnitNotNull(Ingredient ingredient)
    {
        if (ingredient.MeasurementUnit == null || ingredient.MeasurementUnit.Trim() == "")
        {
            throw new Exception("Measurement Unit is required");
        }
        if (ingredient.MeasurementUnit.Trim() != "Kg"
        && ingredient.MeasurementUnit.Trim() != "g"
        && ingredient.MeasurementUnit.Trim() != "L"
        && ingredient.MeasurementUnit.Trim() != "mL"
        && ingredient.MeasurementUnit.Trim() != "un")
        {
            throw new Exception("Measurement Unit must be Kg, g, L, mL or un");
        }
    }
    public void EnsureTotalAmountNotNegative(Ingredient ingredient)
    {
        if (ingredient.TotalAmount <= 0)
        {
            throw new Exception("Total Amount must be greater than 0");
        }
    }
    public void EnsureTotalValueNotNegative(Ingredient ingredient)
    {
        if (ingredient.TotalValue <= 0)
        {
            throw new Exception("Total Value must be greater than 0");
        }
    }
    public void EnsureDefaultAmountNotNegative(Ingredient ingredient)
    {
        if (ingredient.DefaultAmount <= 0)
        {
            throw new Exception("Default Amount must be greater than 0");
        }
    }
    public double DivedeTotalAmountByTotalValueToGetVPA(Ingredient ingredient)
    {
        if (ingredient.MeasurementUnit == "un")
        {
            return ingredient.TotalValue;
        }
        if (ingredient.MeasurementUnit == "Kg")
        {
            return ingredient.TotalValue;
        }
        if (ingredient.MeasurementUnit == "g")
        {
            return ProportionalRule(ingredient.TotalAmount, ingredient.TotalValue, 1000);
        }
        if (ingredient.MeasurementUnit == "L")
        {
            return ingredient.TotalValue;
        }
        if (ingredient.MeasurementUnit == "mL")
        {
            return ProportionalRule(ingredient.TotalAmount, ingredient.TotalValue, 1000);
        }
        return 0;
    }
    public double ProportionalRule(double knownWeight, double knownPrice, double desiredWeight)
    {
        return knownPrice * desiredWeight / knownWeight;
    }
}