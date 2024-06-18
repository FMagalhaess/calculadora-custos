using calculadora_custos.Models;
using calculadora_custos.DTO;
namespace calculadora_custos.Repository;
    public interface IPresentationCostRepository{
        List<PresentationCost> GetPresentationCost();
        PresentationCost CreatePresentationCost(PresentationCost presentationCost);
        void DeletePresentationCost(int id);
        void UpdatePresentationCost(int id, PresentationCost presentationCost);
        bool PresentationCostExists(int id);
    }