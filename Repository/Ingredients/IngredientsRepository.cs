using calculadora_custos.Models;
using calculadora_custos.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using calculadora_custos.Results;
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

    public Result<Ingredient> CreateIngredient(Ingredient ingredient)
    {
        Result<string> validation = ValidateIngredientFoCreation(ingredient);
        if (validation.IsSuccess != true)
            return Result<Ingredient>.Fail(validation.Error);

        ingredient.ValuePerAmount = EnsureFields.DivedeTotalAmountByTotalValueToGetValuePerAmount(ingredient);

        _context.Ingredients.Add(ingredient);
        _context.SaveChanges();
        return Result<Ingredient>.Ok(ingredient);
        
    }

    private static Result<string> ValidateIngredientFoCreation(Ingredient ingredient)
    {
        return EnsureFields.RunValidations(
            EnsureFields.NotNullOrEmpty(ingredient.Name!, "ingredient name"),
            EnsureFields.NotNullOrEmpty(ingredient.MeasurementUnit!, "Measurement unit"),
            EnsureFields.EnsureMeasurementUnitIsValid(ingredient.MeasurementUnit!),
            EnsureFields.EnsureNotNegativeOrZero(ingredient.TotalAmount, "Total amount"),
            EnsureFields.EnsureNotNegativeOrZero(ingredient.TotalValue, "TotalValue"),
            EnsureFields.EnsureNotNegativeOrZero(ingredient.DefaultAmount, "DefaultAmount")
        );
    }


    public void DeleteIngredient(string id)
    {
        try
        {
            int.TryParse(id, out int ingredientId);
            if (!IngredientExists(ingredientId))
            {
                throw new Exception($"id {ingredientId} not found");
            }

            _context.Ingredients.Find(ingredientId);
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }


    public Ingredient UpdateIngredient(string id, Ingredient ingredient)
    {
        try
        {
            int.TryParse(id, out int idToSearch);
            ingredient.Id = idToSearch;
            if(!IngredientExists(idToSearch))
            {
                throw new Exception($"id {idToSearch} not found");
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        _context.Ingredients.Update(ingredient);
        _context.SaveChanges();
        return ingredient;
    }

    public bool IngredientExists(int id)
    {
        return _context.Ingredients.Any(i => i.Id == id);
    }
}