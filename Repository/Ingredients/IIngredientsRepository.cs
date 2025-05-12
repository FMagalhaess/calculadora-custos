using calculadora_custos.Models;
using calculadora_custos.DTO;
using calculadora_custos.Results;

namespace calculadora_custos.Repository;
    public interface IIngredientRepository{
        Task<List<Ingredient>> GetIngredients();
        Task<Result<Ingredient>> CreateIngredient(Ingredient ingredient);
        Task<Result<Ingredient>> DeleteIngredient(string id);
        Task<Result<Ingredient>> UpdateIngredient(string id, Ingredient ingredient);
        bool IngredientExists(int id);
    }