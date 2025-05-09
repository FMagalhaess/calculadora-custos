namespace calculadora_custos.Models
{
    public class IngredientToRecipe
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
    }
}