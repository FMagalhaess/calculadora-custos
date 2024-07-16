using calculadora_custos.Models;
using calculadora_custos.DTO;
namespace calculadora_custos.Repository;

public interface IPresentationToRecipe
{
    List<PresentationToRecipe> GetPresentationsToRecipe();
    PresentationToRecipe CreatePresentationToRecipe(PresentationToRecipe presentationToRecipe);
    void DeletePresentationToRecipe(int id);
    void UpdatePresentationToRecipe(int id, PresentationToRecipe presentationToRecipe);
    bool PresentationToRecipeExists(int id);
}