using System.Numerics;
using calculadora_custos.DTO;
using calculadora_custos.Models;
using calculadora_custos.Results;

namespace calculadora_custos.Services;
public static class EnsureFields{

    public static Result<string> RunValidations(params Result<string>[] validations)
    {
        return validations.FirstOrDefault(v => !v.IsSuccess)
                      ?? Result<string>.Ok("All validations passed.");
    }
    public static Result<string> NotNullOrEmpty(string value, string fieldName)
    {
        return (string.IsNullOrWhiteSpace(value)) ? Result<string>.Fail($"{fieldName} cannot be null or empty.") : Result<string>.Ok(value);
    }
    public static Result<string> EnsureMeasurementUnitIsValid(string measurementUnit)
    {
        Span<string> validMeasurementUnit = ["Kg", "g", "L", "mL", "un"];
        foreach (var m in validMeasurementUnit)
        {
            if (m == measurementUnit.Trim())
            {
                return Result<string>.Ok("pass");
            }
        }

        return Result<string>.Fail("measurement unit is not valid.");
    }

    public static Result<string> EnsureNotNegativeOrZero<T>(T value, string fieldName) where T : INumber<T>
    {
        return value <= T.Zero ? Result<string>.Fail($"{fieldName} cannot be negative or zero.") : Result<string>.Ok((value).ToString());
    }

    public static void EnsureNameNotNull(string name)
    {
        if (name == null || name.Trim() == "")
        {
            throw new Exception("Name is required");
        }
    }

    public static void EnsureEmailNotNull(string email)
    {
        if (email == null || email.Trim() == "")
        {
            throw new Exception("Email is required");
        }
    }

    public static void EnsurePasswordNotNull(string password)
    {
        if (password == null || password.Trim() == "")
        {
            throw new Exception("Password is required");
        }
    }

    public static void EnsureMeasureUnitNotNull(string MeasurementUnit)
    {
        if (MeasurementUnit == null || MeasurementUnit.Trim() == "")
        {
            throw new Exception("Measurement Unit is required");
        }
        if (MeasurementUnit.Trim() != "Kg"
        && MeasurementUnit.Trim() != "g"
        && MeasurementUnit.Trim() != "L"
        && MeasurementUnit.Trim() != "mL"
        && MeasurementUnit.Trim() != "un")
        {
            throw new Exception("Measurement Unit must be Kg, g, L, mL or un");
        }
    }
    public static void EnsureTotalAmountNotNegative(double TotalAmount)
    {
        if (TotalAmount <= 0)
        {
            throw new Exception("Total Amount must be greater than 0");
        }
    }
    public static void EnsureTotalValueNotNegative(double TotalValue)
    {
        if (TotalValue <= 0)
        {
            throw new Exception("Total Value must be greater than 0");
        }
    }
    public static void EnsureDefaultAmountNotNegative(double DefaultAmount)
    {
        if (DefaultAmount <= 0)
        {
            throw new Exception("Default Amount must be greater than 0");
        }
    }
    
    public static void EnsureIngredientsListNotNull(List<int> ingredients)
    {
        if (ingredients == null || ingredients.Count == 0)
        {
            throw new Exception("Ingredients list is required");
        }
    }
    public static void EnsurePreparationListNotNull(List<int> preparations)
    {
        if (preparations == null || preparations.Count == 0)
        {
            throw new Exception("Preparations list is required");
        }
    }
    public static void EnsurePresentationListNotNull(List<int> presentations)
    {
        if (presentations == null || presentations.Count == 0)
        {
            throw new Exception("Presentations list is required");
        }
    }
    public static void EnsureDeliveryCostListNotNull(List<int> deliveryCosts)
    {
        if (deliveryCosts == null || deliveryCosts.Count == 0)
        {
            throw new Exception("Delivery Costs list is required");
        }
    }
    public static void CheckIfItemListsAreEqual(List<int> list1, List<decimal> list2)
    {
        if (list1.Count != list2.Count)
        {
            throw new Exception("Lists have different sizes");
        }
    }
    public static void EnsureFieldsCheckerToCreateRecipe(InputRecipeFromDTO recipe)
    {
        try
        {
            EnsureNameNotNull(recipe.Name!);
            EnsureIngredientsListNotNull(recipe.Ingredients!);
            EnsurePreparationListNotNull(recipe.PreparationCostItems!);
            EnsurePresentationListNotNull(recipe.PresentationCostItems!);
            EnsureDeliveryCostListNotNull(recipe.DeliveryCostItems!);
            CheckIfItemListsAreEqual(recipe.Ingredients!, recipe.IngredientsAmount!);
            CheckIfItemListsAreEqual(recipe.PreparationCostItems!, recipe.PreparationCostItemsAmount!);
            CheckIfItemListsAreEqual(recipe.PresentationCostItems!, recipe.PresentationCostItemsAmount!);
            CheckIfItemListsAreEqual(recipe.DeliveryCostItems!, recipe.DeliveryCostItemsAmount!);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}