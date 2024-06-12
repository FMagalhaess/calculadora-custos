using calculadora_custos.Models;
using calculadora_custos.Services;
namespace calculadora_custos.Repository;

public class RecipeRepository : IRecipeRepository
{
    private readonly IDbContext _context;
    public RecipeRepository(IDbContext context)
    {
        _context = context;
    }
    public Recipe CreateRecipe(Recipe recipe)
    {
        throw new NotImplementedException();
    }

    public List<Recipe> GetRecipes()
    {
        return _context.Recipes.ToList();
    }
}