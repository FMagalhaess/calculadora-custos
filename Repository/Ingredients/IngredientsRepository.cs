using calculadora_custos.Models;
using calculadora_custos.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using calculadora_custos.Results;
using calculadora_custos.Services;
using Microsoft.EntityFrameworkCore;

namespace calculadora_custos.Repository;

public class IngredientRepository(IDbContext context) : IIngredientRepository
{
    public async Task<List<Ingredient>> GetIngredients()
    {
        return await context.Ingredients.ToListAsync();
    }

    public async Task<Result<Ingredient>> CreateIngredient(Ingredient ingredient)
    {
        var validation = ValidateIngredient(ingredient);
        if (validation.IsSuccess != true)
            return Result<Ingredient>.Fail(validation.Error);

        ingredient.ValuePerAmount = DivideTotalAmountByTotalValueToGetValuePerAmount(ingredient);

        await context.Ingredients.AddAsync(ingredient);
        await context.SaveChangesAsync();
        
        return Result<Ingredient>.Ok(ingredient);
    }
    
    public async Task<Result<Ingredient>> UpdateIngredient(string id, Ingredient ingredient)
    {
        if(!int.TryParse(id, out int idToSearch))
            return Result<Ingredient>.Fail("Invalid Id");
        
        var valide = ValidateIngredient(ingredient);
        if (valide.IsSuccess != true)
            return Result<Ingredient>.Fail(valide.Error);
        
        ingredient.Id = idToSearch;
        
        if(!IngredientExists(idToSearch))
        {
            return Result<Ingredient>.Fail("Ingredient not found");
        }
        
        context.Ingredients.Update(ingredient);
        await context.SaveChangesAsync();
        
        return Result<Ingredient>.Ok(ingredient);
    }
    public async Task<Result<Ingredient>> DeleteIngredient(string id)
    {
        if (!int.TryParse(id, out var ingredientId))
            return Result<Ingredient>.Fail("Ingredient Id must be a number.");

        if (!IngredientExists(ingredientId))
            return Result<Ingredient>.Fail($"Ingredient with id: {id} does not exist.");

        var ingredient = await context.Ingredients.FindAsync(ingredientId);
        ingredient!.DeletedAt = DateTime.Now;
        
        context.Ingredients.Update(ingredient);
        await context.SaveChangesAsync();
        
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

    private static Result<string> ValidateIngredient(Ingredient ingredient)
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

    

    public bool IngredientExists(int id)
    {
        return context.Ingredients.Any(i => i.Id == id);
    }
}