namespace calculadora_custos.Models
{
    public class FixedCost
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Cost { get; set; }
        public string? MonthlyFrequency { get; set; }
    }
}