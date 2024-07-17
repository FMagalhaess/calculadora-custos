using calculadora_custos.Models;
using calculadora_custos.DTO;
using System.Collections.Generic;
using calculadora_custos.Services;

namespace calculadora_custos.Repository;

public class PreparationToRecipeRepository : IPreparationToRecipe
{
    private readonly IDbContext _context;
    private readonly IPreparationCostRepository _preparationRepository;
    public PreparationToRecipeRepository(IDbContext context, IPreparationCostRepository preparationRepository)
    {
        _context = context;
        _preparationRepository = preparationRepository;
    }

    public PreparationToRecipe CreatePreparationToRecipe(PreparationToRecipe preparationToRecipe)
    {
        try
        {
            if(!_preparationRepository.PreparationCostExists(preparationToRecipe.PreparationId))
            {
                throw new Exception("Preparation not found");
            }
            _context.PreparationToRecipes.Add(preparationToRecipe);
            _context.SaveChanges();
            return preparationToRecipe;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void DeletePreparationToRecipe(int id)
    {
        throw new NotImplementedException();
    }

    public List<PreparationToRecipe> GetPreparationToRecipe()
    {
        return _context.PreparationToRecipes.ToList();
    }

    public bool PreparationToRecipeExists(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdatePreparationToRecipe(int id, PreparationToRecipe preparationToRecipe)
    {
        throw new NotImplementedException();
    }
}