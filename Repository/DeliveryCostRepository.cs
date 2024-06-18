using calculadora_custos.Models;
using calculadora_custos.Services;
namespace calculadora_custos.Repository
{
    public class DeliveryCostRepository : IDeliveryCostRepository
    {
        private readonly IDbContext _context;

        public DeliveryCostRepository(IDbContext context)
        {
            _context = context;
        }

        public DeliveryCost CreateDeliveryCost(DeliveryCost deliveryCost)
        {
            try
            {
                EnsureFields.EnsureNameNotNull(deliveryCost.Name);
                EnsureFields.EnsureTotalAmountNotNegative(deliveryCost.Amount);
                EnsureFields.EnsureTotalValueNotNegative(deliveryCost.Value);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            _context.DeliveryCosts.Add(deliveryCost);
            _context.SaveChanges();
            return deliveryCost;
        }

        public void DeleteDeliveryCost(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeliveryCostExists(int id)
        {
            throw new NotImplementedException();
        }

        public List<DeliveryCost> GetAllDeliveryCosts()
        {
            return _context.DeliveryCosts.ToList();
        }

        public void UpdateDeliveryCost(int id, DeliveryCost deliveryCost)
        {
            throw new NotImplementedException();
        }
    }
}