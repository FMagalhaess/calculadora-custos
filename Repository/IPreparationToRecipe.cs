using calculadora_custos.Models;
using calculadora_custos.DTO;
namespace calculadora_custos.Repository;
public interface IPreparationToRecipe
{
    List<PreparationCost> GetPreparationToRecipe();
    PreparationCost CreatePreparationToRecipe(PreparationCost preparationToRecipe);
    void DeletePreparationToRecipe(int id);
    void UpdatePreparationToRecipe(int id, PreparationCost preparationToRecipe);
    bool PreparationToRecipeExists(int id);
}