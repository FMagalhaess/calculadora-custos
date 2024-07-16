using calculadora_custos.Models;
using calculadora_custos.DTO;
using System.Collections.Generic;
using calculadora_custos.Services;

namespace calculadora_custos.Repository;

public class PreparationToRecipeRepository : IPreparationToRecipe
{
    private readonly IDbContext _context;
    private readonly IPreparationCostRepository _preparationRepository;
    private readonly IRecipeRepository _recipeRepository;
    public PreparationToRecipeRepository(IDbContext context, IPreparationCostRepository preparationRepository, IRecipeRepository recipeRepository)
    {
        _context = context;
        _preparationRepository = preparationRepository;
        _recipeRepository = recipeRepository;
    }

    public PreparationToRecipe CreatePreparationToRecipe(PreparationToRecipe preparationToRecipe)
    {
        try
        {
            if(!_recipeRepository.RecipeExists(preparationToRecipe.RecipeId))
            {
                throw new Exception("Recipe not found");
            }
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