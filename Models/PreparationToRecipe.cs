namespace calculadora_custos.Models
{
    public class PreparationToRecipe
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
        public int PreparationId { get; set; }
        public PreparationCost? Preparation { get; set; }
    }
}