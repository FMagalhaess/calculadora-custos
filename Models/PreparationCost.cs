namespace calculadora_custos.Models
{
    public class PreparationCost
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? AmountType { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
    }
}