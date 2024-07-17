using calculadora_custos.Models;
using calculadora_custos.Repository;
using Microsoft.EntityFrameworkCore;

using (var db = new MyContext())
{
    db.Database.EnsureCreated();
}
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyContext>();
builder.Services.AddScoped<IDbContext, MyContext>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IDeliveryCostRepository, DeliveryCostRepository>();
builder.Services.AddScoped<IPresentationCostRepository, PresentationCostRepository>();
builder.Services.AddScoped<IPreparationCostRepository, PreparationCostRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IDeliveryCostsToRecipe, DeliveryCostToRecipeRepository>();
builder.Services.AddScoped<IPresentationToRecipe, PresentationToRecipeRepository>();
builder.Services.AddScoped<IPreparationToRecipe, PreparationToRecipeRepository>();
builder.Services.AddScoped<IIngredientsToRecipe, IngredientsToRecipeRepository>();
builder.Services.AddScoped(provider => new Lazy<IIngredientsToRecipe>(()=> provider.GetRequiredService<IIngredientsToRecipe>()));
builder.Services.AddScoped(provider => new Lazy<IPreparationToRecipe>(()=> provider.GetRequiredService<IPreparationToRecipe>()));
builder.Services.AddScoped(provider => new Lazy<IPresentationToRecipe>(()=> provider.GetRequiredService<IPresentationToRecipe>()));
builder.Services.AddScoped(provider => new Lazy<IDeliveryCostsToRecipe>(()=> provider.GetRequiredService<IDeliveryCostsToRecipe>()));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
