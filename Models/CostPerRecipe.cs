namespace calculadora_custos.Models
{
    public class CostPerRecipe
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
        public int IngredientId { get; set; }
        public Ingredient? Ingredient { get; set; }
        public int PresentationCostId { get; set; }
        public PresentationCost? PresentationCost { get; set; }
        public int PreparationCostId { get; set; }
        public PreparationCost? PreparationCost { get; set; }
        public int DeliveryCostId { get; set; }
        public DeliveryCost? DeliveryCost { get; set; }
    }
}