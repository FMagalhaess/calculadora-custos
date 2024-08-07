using calculadora_custos.DTO;
using calculadora_custos.Models;

namespace calculadora_custos.Services;
public static class EnsureFields{
    public static void EnsureNameNotNull(string name)
    {
        if (name == null || name.Trim() == "")
        {
            throw new Exception("Name is required");
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
    public static double DivedeTotalAmountByTotalValueToGetVPA(Ingredient ingredient)
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
    public static double ProportionalRule(double knownWeight, double knownPrice, double desiredWeight)
    {
        return knownPrice * desiredWeight / knownWeight;
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