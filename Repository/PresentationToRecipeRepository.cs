using calculadora_custos.Models;
using calculadora_custos.DTO;
using System.Collections.Generic;
using calculadora_custos.Services;

namespace calculadora_custos.Repository;

public class PresentationToRecipeRepository : IPresentationToRecipe
{
    private readonly IDbContext _context;
    private readonly IPresentationCostRepository _presentationRepository;
    public PresentationToRecipeRepository(IDbContext context, IPresentationCostRepository presentationRepository)
    {
        _context = context;
        _presentationRepository = presentationRepository;
    }
    public PresentationToRecipe CreateInstanceOfPresentationToRecipe(int recipeId, int presentationId)
    {
        PresentationToRecipe presentationToRecipe = new()
        {
            RecipeId = recipeId,
            PresentationId = presentationId
        };
        return presentationToRecipe;
    }
    public PresentationToRecipe CreatePresentationToRecipe(int recipeId, int presentationId)
    {
        try
        {
            PresentationToRecipe presentationToRecipe = CreateInstanceOfPresentationToRecipe(recipeId, presentationId);
            if(!_presentationRepository.PresentationCostExists(presentationToRecipe.PresentationId))
            {
                throw new Exception("Presentation not found");
            }
            _context.PresentationToRecipes.Add(presentationToRecipe);
            _context.SaveChanges();
            return presentationToRecipe;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void DeletePresentationToRecipe(int id)
    {
        throw new NotImplementedException();
    }

    public List<PresentationToRecipe> GetPresentationsToRecipe()
    {
        return _context.PresentationToRecipes.ToList();
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