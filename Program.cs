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
