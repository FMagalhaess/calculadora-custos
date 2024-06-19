using calculadora_custos.Models;
using calculadora_custos.DTO;
namespace calculadora_custos.Repository;

public interface IPresentationToRecipe
{
    List<PresentationCost> GetPresentationsToRecipe();
    PresentationCost CreatePresentationToRecipe(PresentationCost presentationToRecipe);
    void DeletePresentationToRecipe(int id);
    void UpdatePresentationToRecipe(int id, PresentationCost presentationToRecipe);
    bool PresentationToRecipeExists(int id);
}