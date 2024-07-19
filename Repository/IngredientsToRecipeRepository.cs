using calculadora_custos.Models;
using calculadora_custos.DTO;
using System.Collections.Generic;
using calculadora_custos.Services;

namespace calculadora_custos.Repository;

public class IngredientsToRecipeRepository : IIngredientsToRecipe
{
    private readonly IDbContext _context;
    private readonly IIngredientRepository _ingredientRepository;
    public IngredientsToRecipeRepository(IDbContext context, IIngredientRepository ingredientRepository)
    {
        _context = context;
        _ingredientRepository = ingredientRepository;
    }
    public IngredientToRecipe CreateInstanceOfIngredientsToRecipe(int RecipeId, int IngredientId)
    {
        IngredientToRecipe ingredientsToRecipe = new()
        {
            IngredientId = IngredientId,
            RecipeId = RecipeId
        };
        return ingredientsToRecipe;
    }
    public IngredientToRecipe CreateIngredientsToRecipe(int RecipeId, int IngredientId)
    {
        IngredientToRecipe ingredientsToRecipe;
        try
        {
            if(!_ingredientRepository.IngredientExists(IngredientId))
            {
                throw new Exception("Ingredient not found");
            }
            ingredientsToRecipe = CreateInstanceOfIngredientsToRecipe(RecipeId, IngredientId);
            _context.IngredientToRecipes.Add(ingredientsToRecipe);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return ingredientsToRecipe;
    }

    public void DeleteIngredientsToRecipe(int id)
    {
        throw new NotImplementedException();
    }

    public List<IngredientToRecipe> GetIngredientsToRecipe()
    {
        return _context.IngredientToRecipes.ToList();
    }

    public bool IngredientsToRecipeExists(int id)
    {
        return _context.IngredientToRecipes.Any(e => e.Id == id);
    }

    public void UpdateIngredientsToRecipe(int id, IngredientToRecipe ingredientsToRecipe)
    {
        throw new NotImplementedException();
    }
}