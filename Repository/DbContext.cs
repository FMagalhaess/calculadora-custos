using calculadora_custos.Models;
using Microsoft.EntityFrameworkCore;

namespace calculadora_custos.Repository
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<PresentationCost> PresentationCosts { get; set; }
        public DbSet<PreparationCost> PreparationCosts { get; set; }
        public DbSet<DeliveryCost> DeliveryCosts { get; set; }
        public DbSet<FixedCost> FixedCosts { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Server=127.0.0.1;Database=calculadora-custos;User=SA;Password=SqlServerSenhaSegura123!;TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(connectionString);
        }

        }
    }
}