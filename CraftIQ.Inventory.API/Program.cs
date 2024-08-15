using CraftIQ.Inventory.Core.Interfaces;
using CraftIQ.Inventory.Infrastructure;
using CraftIQ.Inventory.Services.CategoriesImplementions;
using huzcodes.Extensions.Exceptions;
using huzcodes.Persistence.Interfaces.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// adding db context registration
var inventoryDbConnectionString = builder.Configuration.GetSection("ConnectionStrings:InventoryDbConnection");
builder.Services.AddInventoryDbContext(inventoryDbConnectionString.Value!);
builder.Services.AddInventoryDbContext(inventoryDbConnectionString.Value!);
builder.Services.AddInfrastructureRegistrations();
builder.Services.AddLogging();
builder.Services.AddInfrastructureRegistrations();
//builder.Services.AddInfrastructureRegistrations();
builder.Services.AddScoped<ICategoriesServices, CategoriesServices>();
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
// Register the exception handler extension
app.AddExceptionHandlerExtension();

app.UseAuthorization();

app.MapControllers();

app.Run();
