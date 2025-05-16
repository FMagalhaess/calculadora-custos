using calculadora_custos.DTO;
using calculadora_custos.Results;

namespace calculadora_custos.Services.Validation;

public interface IValideInputs
{
    Result<string> ValideRecipe(InputRecipeFromDto recipe);
}