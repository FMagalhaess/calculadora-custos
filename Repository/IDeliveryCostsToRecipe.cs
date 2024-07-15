using calculadora_custos.Models;
using calculadora_custos.DTO;
namespace calculadora_custos.Repository;

public interface IDeliveryCostsToRecipe
{
    List<DeliveryToRecipe> GetDeliveryCostsToRecipe();
    DeliveryToRecipe CreateDeliveryCostsToRecipe(DeliveryToRecipe deliveryCostsToRecipe);
    void DeleteDeliveryCostsToRecipe(int id);
    void UpdateDeliveryCostsToRecipe(int id, DeliveryToRecipe deliveryCostsToRecipe);
    bool DeliveryCostsToRecipeExists(int id);
}