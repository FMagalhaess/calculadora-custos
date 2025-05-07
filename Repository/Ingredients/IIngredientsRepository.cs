using calculadora_custos.Models;
using calculadora_custos.DTO;
using calculadora_custos.Results;

namespace calculadora_custos.Repository;
    public interface IIngredientRepository{
        List<Ingredient> GetIngredients();
        Result<Ingredient> CreateIngredient(Ingredient ingredient);
        void DeleteIngredient(string id);
        Ingredient UpdateIngredient(string id, Ingredient ingredient);
        bool IngredientExists(int id);
    }