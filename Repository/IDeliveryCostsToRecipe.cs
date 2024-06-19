using calculadora_custos.Models;
using calculadora_custos.DTO;
namespace calculadora_custos.Repository;

public interface IDeliveryCostsToRecipe
{
    List<DeliveryCost> GetDeliveryCostsToRecipe();
    DeliveryCost CreateDeliveryCostsToRecipe(DeliveryCost deliveryCostsToRecipe);
    void DeleteDeliveryCostsToRecipe(int id);
    void UpdateDeliveryCostsToRecipe(int id, DeliveryCost deliveryCostsToRecipe);
    bool DeliveryCostsToRecipeExists(int id);
}