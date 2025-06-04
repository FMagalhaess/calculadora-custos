namespace calculadora_custos.Models
{
    public class CostToRecipe
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int CostType { get; set; }
        public int RecipeId { get; set; }
        public decimal Quantity { get; set; }
        public int CostId { get; set; }
    }
}