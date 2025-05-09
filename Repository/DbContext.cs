using calculadora_custos.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace calculadora_custos.Repository
{
    public class MyContext : DbContext, IDbContext
    {
        public MyContext()
        {
        }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<FixedCost> FixedCosts { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<IngredientToRecipe> IngredientToRecipes { get; set; }
        public DbSet<CostItem> CostItems { get; set; }
        public DbSet<VariableCost> VariableCost { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=127.0.0.1;Database=calculadora-custos;User=SA;Password=SqlServerSenhaSegura123!;TrustServerCertificate=True;";

                optionsBuilder.UseSqlServer(connectionString);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // somente tipos que implementam ISoftDeletable
                if (!typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType))
                    continue;

                // param ‘e’ do tipo da entidade (ex: FixedCost e)
                var parameter = Expression.Parameter(entityType.ClrType, "e");

                // método EF.Property<DateTime?>(...)
                var propertyMethod = typeof(EF)
                    .GetMethod(nameof(EF.Property), new[] { typeof(object), typeof(string) })
                    !.MakeGenericMethod(typeof(DateTime?));

                // expressao: EF.Property<DateTime?>(e, "DeletedAt")
                var deletedAtProperty = Expression.Call(
                    propertyMethod,
                    parameter,
                    Expression.Constant(nameof(ISoftDeletable.DeletedAt))
                );

                // expressao: EF.Property<DateTime?>(e, "DeletedAt") == null
                var compareToNull = Expression.Equal(
                    deletedAtProperty,
                    Expression.Constant(null, typeof(DateTime?))
                );

                // lambda: e => EF.Property<DateTime?>(e, "DeletedAt") == null
                var lambda = Expression.Lambda(compareToNull, parameter);

                // finalmente, registra o filtro global
                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}