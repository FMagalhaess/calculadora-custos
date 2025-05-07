namespace calculadora_custos.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public string? MeasurementUnit { get; set; }
        public double TotalAmount { get; set; }
        public double TotalValue { get; set; }
        public double ValuePerAmount { get; set; }
        public double DefaultAmount { get; set; }
    }
}