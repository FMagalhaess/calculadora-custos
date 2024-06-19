using calculadora_custos.Models;
using calculadora_custos.DTO;
using System.Collections.Generic;
using calculadora_custos.Services;

namespace calculadora_custos.Repository;

public class IngredientsToRecipe : IIngredientsToRecipe
{
    private readonly IDbContext _context;
    public IngredientsToRecipe(IDbContext context)
    {
        _context = context;
    }

    public Ingredient CreateIngredientsToRecipe(Ingredient ingredientsToRecipe)
    {
        throw new NotImplementedException();
    }

    public void DeleteIngredientsToRecipe(int id)
    {
        throw new NotImplementedException();
    }

    public List<Ingredient> GetIngredientsToRecipe()
    {
        throw new NotImplementedException();
    }

    public bool IngredientsToRecipeExists(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateIngredientsToRecipe(int id, Ingredient ingredientsToRecipe)
    {
        throw new NotImplementedException();
    }
}