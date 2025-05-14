using System.Numerics;
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

        return Result<string>.Fail($"measurement unit must be one of: {measurementUnit}.");
    }

    public static Result<string> EnsureListDoesNotContainZeroOrNegative<T>(List<T> list, string fieldName)
        where T : INumber<T>
    {
        foreach (var n in list)
        {
            if(n <= T.Zero)
                return Result<string>.Fail($"{fieldName} must be positive.");
        }
        return Result<string>.Ok("pass");
    }
    public static Result<string> EnsureNotNegativeOrZero<T>(T value, string fieldName) where T : INumber<T>
    {
        return value <= T.Zero ? Result<string>.Fail($"{fieldName} cannot be negative or zero.") : Result<string>.Ok((value).ToString()!);
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

    public static void EnsureMeasureUnitNotNull(string measurementUnit)
    {
        if (measurementUnit == null || measurementUnit.Trim() == "")
        {
            throw new Exception("Measurement Unit is required");
        }
        if (measurementUnit.Trim() != "Kg"
        && measurementUnit.Trim() != "g"
        && measurementUnit.Trim() != "L"
        && measurementUnit.Trim() != "mL"
        && measurementUnit.Trim() != "un")
        {
            throw new Exception("Measurement Unit must be Kg, g, L, mL or un");
        }
    }
    public static Result<string> EnsureListNotNullOrEmpty<T>(IList<T> list, string fieldName)
    {
        if (list == null! || list.Count == 0)
        {
            return Result<string>.Fail($"{fieldName} cannot be null or empty.");
        }
        return Result<string>.Ok("Pass");
    }
    
    public static Result<string> CheckIfItemListsAreEqualRr(List<int> list1, List<decimal> list2)
    {
        return list1.Count == list2.Count ? Result<string>.Ok("Pass") : Result<string>.Fail("Lists have different sizes");
    }
}