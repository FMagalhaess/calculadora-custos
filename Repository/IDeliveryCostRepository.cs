using calculadora_custos.Models;
namespace calculadora_custos.Repository;

public interface IDeliveryCostRepository {
    List<DeliveryCost> GetAllDeliveryCosts();
    DeliveryCost CreateDeliveryCost(DeliveryCost deliveryCost);
}