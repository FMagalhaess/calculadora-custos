using calculadora_custos.Models;
using calculadora_custos.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using calculadora_custos.Results;
using calculadora_custos.Services;

namespace calculadora_custos.Repository;

public class IngredientRepository(IDbContext context) : IIngredientRepository
{
    public List<Ingredient> GetIngredients()
    {
        return context.Ingredients.ToList();
    }

    public Result<Ingredient> CreateIngredient(Ingredient ingredient)
    {
        var validation = ValidateIngredientFoCreation(ingredient);
        if (validation.IsSuccess != true)
            return Result<Ingredient>.Fail(validation.Error);

        ingredient.ValuePerAmount = DivideTotalAmountByTotalValueToGetValuePerAmount(ingredient);

        context.Ingredients.Add(ingredient);
        context.SaveChanges();
        return Result<Ingredient>.Ok(ingredient);
        
    }
    private static double DivideTotalAmountByTotalValueToGetValuePerAmount(Ingredient ingredient)
    {
        return ingredient.MeasurementUnit switch
        {
            "un" => ingredient.TotalValue,
            "kg" => ingredient.TotalValue,
            "g" => ProportionalRule(ingredient.TotalAmount, ingredient.TotalValue, 1000),
            "L" => ingredient.TotalValue,
            "mL" => ProportionalRule(ingredient.TotalAmount, ingredient.TotalValue, 1000),
            _ => ingredient.TotalValue
        };
    }
    
    private static double ProportionalRule(double knownWeight, double knownPrice, double desiredWeight)
    {
        return knownPrice * desiredWeight / knownWeight;
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


    public Result<Ingredient> DeleteIngredient(string id)
    {
        if (!int.TryParse(id, out var ingredientId))
        {
            return Result<Ingredient>.Fail("Ingredient Id must be a number.");
        }

        if (!IngredientExists(ingredientId))
        {
            return Result<Ingredient>.Fail($"Ingredient with id: {id} does not exist.");
        }

        var ingredient = context.Ingredients.Find(ingredientId);
        ingredient!.DeletedAt = DateTime.Now;
        context.Ingredients.Update(ingredient);
        context.SaveChanges();
        return Result<Ingredient>.Ok(ingredient);
        
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
        context.Ingredients.Update(ingredient);
        context.SaveChanges();
        return ingredient;
    }

    public bool IngredientExists(int id)
    {
        return context.Ingredients.Any(i => i.Id == id);
    }
}