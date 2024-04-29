namespace calculadora_custos.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? QuantityType { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double PricePerAmount { get; set; }
    }
}