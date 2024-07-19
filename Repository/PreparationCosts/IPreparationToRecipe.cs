using calculadora_custos.Models;
using calculadora_custos.DTO;
namespace calculadora_custos.Repository;
public interface IPreparationToRecipe
{
    List<PreparationToRecipe> GetPreparationToRecipe();
    PreparationToRecipe CreatePreparationToRecipe(int recipeId, int preparationId);
    PreparationToRecipe CreateInstanceOfPreparationToRecipe(int recipeId, int preparationId);
    void DeletePreparationToRecipe(int id);
    void UpdatePreparationToRecipe(int id, PreparationToRecipe preparationToRecipe);
    bool PreparationToRecipeExists(int id);
}