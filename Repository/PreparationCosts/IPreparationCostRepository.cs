using calculadora_custos.Models;
namespace calculadora_custos.Repository;

public interface IPreparationCostRepository {
    List<PreparationCost> GetPreparationCost();
    PreparationCost CreatePreparationCost(PreparationCost preparationCost);
    void DeletePreparationCost(int id);
    void UpdatePreparationCost(int id, PreparationCost preparationCost);
    bool PreparationCostExists(int id);
}