using calculadora_custos.Models;
using Microsoft.EntityFrameworkCore;
namespace calculadora_custos.Repository;

public interface IDbContext
{
    public DbSet<User> Users { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<PresentationCost> PresentationCosts { get; set; }
        public DbSet<PreparationCost> PreparationCosts { get; set; }
        public DbSet<DeliveryCost> DeliveryCosts { get; set; }
        public DbSet<FixedCost> FixedCosts { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<IngredientToRecipe> IngredientToRecipes { get; set; }
        public DbSet<PresentationToRecipe> PresentationToRecipes { get; set; }
        public DbSet<PreparationToRecipe> PreparationToRecipes { get; set; }
        public DbSet<DeliveryToRecipe> DeliveryToRecipes { get; set; }
        public DbSet<VariableCost> VariableCost { get; set; }
        public int SaveChanges();
}
