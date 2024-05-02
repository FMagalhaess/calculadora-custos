namespace calculadora_custos.Models
{
    public class PreparationCost
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? MeasurementUnit { get; set; }
        public double TotalValue { get; set; }
        public double DefaultAmount { get; set; }
    }
}