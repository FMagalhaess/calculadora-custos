using calculadora_custos.Models;
using calculadora_custos.DTO;
namespace calculadora_custos.Repository;
    public interface IIngredientRepository{
        List<Ingredient> GetIngredients();
        Ingredient CreateIngredient(Ingredient ingredient);
        void DeleteIngredient(int id);
        void UpdateIngredient(int id, Ingredient ingredient);
        public void EnsureNameNotNull(Ingredient ingredient);
        public void EnsureMeasureUnitNotNull(Ingredient ingredient);
        public void EnsureTotalAmountNotNegative(Ingredient ingredient);
        public void EnsureTotalValueNotNegative(Ingredient ingredient);
        public void EnsureDefaultAmountNotNegative(Ingredient ingredient);
        public double DivedeTotalAmountByTotalValueToGetVPA(Ingredient ingredient);
        public double ProportionalRule(double knownWeight, double knownPrice, double desiredWeight);
    }