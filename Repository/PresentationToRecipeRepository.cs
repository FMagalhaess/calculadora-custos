using calculadora_custos.Models;
using calculadora_custos.DTO;
using System.Collections.Generic;
using calculadora_custos.Services;

namespace calculadora_custos.Repository;

public class PresentationToRecipeRepository : IPresentationToRecipe
{
    private readonly IDbContext _context;
    public PresentationToRecipeRepository(IDbContext context)
    {
        _context = context;
    }
    public PresentationToRecipe CreatePresentationToRecipe(PresentationToRecipe presentationToRecipe)
    {
        throw new NotImplementedException();
    }

    public void DeletePresentationToRecipe(int id)
    {
        throw new NotImplementedException();
    }

    public List<PresentationToRecipe> GetPresentationsToRecipe()
    {
        throw new NotImplementedException();
    }

    public bool PresentationToRecipeExists(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdatePresentationToRecipe(int id, PresentationToRecipe presentationToRecipe)
    {
        throw new NotImplementedException();
    }
}