using calculadora_custos.Models;
using calculadora_custos.DTO;
namespace calculadora_custos.Repository;
    public interface IIngredientRepository{
        List<Ingredient> GetIngredients();
        Ingredient CreateIngredient(Ingredient ingredient);
        void DeleteIngredient(int id);
        void UpdateIngredient(int id, Ingredient ingredient);
        
    }