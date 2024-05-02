namespace calculadora_custos.Models
{
    public class PresentationToRecipe
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
        public int PresentationId { get; set; }
        public PresentationCost? Presentation { get; set; }
    }
}