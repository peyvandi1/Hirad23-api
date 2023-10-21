using Hirad23.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;


var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(options => 
    options.UseSqlite("Data Source=../Registrar.sqlite", b => b.MigrationsAssembly("Hirad23.Api")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build and run the app
var app = builder.Build();

// Configure middleware, routing, etc. 
app.MapControllers();

// Add more middleware or routes as needed.

app.Run();
