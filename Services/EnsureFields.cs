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
}