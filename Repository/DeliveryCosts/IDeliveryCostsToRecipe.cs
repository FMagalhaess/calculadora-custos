using calculadora_custos.Models;
using calculadora_custos.DTO;
namespace calculadora_custos.Repository;

public interface IDeliveryCostsToRecipe
{
    List<DeliveryToRecipe> GetDeliveryCostsToRecipe();
    DeliveryToRecipe CreateDeliveryCostsToRecipe(int RecipeId, int DeliveryCostId);
    void DeleteDeliveryCostsToRecipe(int id);
    void UpdateDeliveryCostsToRecipe(int id, DeliveryToRecipe deliveryCostsToRecipe);
    bool DeliveryCostsToRecipeExists(int id);
    DeliveryToRecipe CreateInstanceOfDeliveryCostsToRecipe(int RecipeId, int DeliveryCostId);
}