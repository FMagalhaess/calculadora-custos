using calculadora_custos.Models;
using calculadora_custos.DTO;
using System.Collections.Generic;
using calculadora_custos.Services;

namespace calculadora_custos.Repository;

public class PreparationToRecipeRepository : IPreparationToRecipe
{
    private readonly IDbContext _context;
    public PreparationToRecipeRepository(IDbContext context)
    {
        _context = context;
    }

    public PreparationCost CreatePreparationToRecipe(PreparationCost preparationToRecipe)
    {
        throw new NotImplementedException();
    }

    public void DeletePreparationToRecipe(int id)
    {
        throw new NotImplementedException();
    }

    public List<PreparationCost> GetPreparationToRecipe()
    {
        throw new NotImplementedException();
    }

    public bool PreparationToRecipeExists(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdatePreparationToRecipe(int id, PreparationCost preparationToRecipe)
    {
        throw new NotImplementedException();
    }
}