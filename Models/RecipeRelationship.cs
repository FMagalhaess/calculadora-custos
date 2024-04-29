namespace calculadora_custos.Models
{
    public class RecipeRelationship
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
        public int FixedCostId { get; set; }
        public FixedCost? FixedCost { get; set; }
        public int DeliveryCostId { get; set; }
        public DeliveryCost? DeliveryCost { get; set; }
    }
}