using calculadora_custos.DTO;
using calculadora_custos.Models;
using calculadora_custos.Results;

namespace calculadora_custos.Services.Validation;

public class ValideInputs : IValideInputs
{
    public Result<string> ValideRecipe(InputRecipeFromDto recipe)
    {
        return EnsureFields.RunValidations(
            EnsureFields.NotNullOrEmpty(recipe.Name!, "Name"),
            EnsureFields.EnsureListNotNullOrEmpty(recipe.Ingredients!, "Ingredients"),
            EnsureFields.EnsureListNotNullOrEmpty(recipe.IngredientsAmount!, "IngredientsAmount"),
            EnsureFields.CheckIfItemListsAreEqualRr(recipe.Ingredients!, recipe.IngredientsAmount!),
            EnsureFields.EnsureListDoesNotContainZeroOrNegative(recipe.Ingredients!, "ingredients"),
            EnsureFields.EnsureListDoesNotContainZeroOrNegative(recipe.IngredientsAmount!, "ingredientsAmount")
        );
    }
}