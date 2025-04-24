using Hirad23.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.OpenApi.Models;
using Hirad23.Api.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;


var builder = WebApplication.CreateBuilder(args);

	string authority = builder.Configuration["Auth0:Authority"] ??
		throw new ArgumentNullException("Auth0:Authority");

	string audience = builder.Configuration["Auth0:Audience"] ??
		throw new ArgumentNullException("Auth0:Audience");

// Add services to the container.

builder.Services.AddControllers();


// Add the AuthN service to the container
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Authority = authority;
    options.Audience = audience;
});


// Add the AuthZ service to the container
builder.Services.AddAuthorization(options =>
	{
		options.AddPolicy("delete:catalog", policy =>
			policy.RequireAuthenticatedUser().RequireClaim("scope", "delete:catalog"));
	});


builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlite("Data Source=../Registrar.sqlite",
    b => b.MigrationsAssembly("Hirad23.Api"))
);


builder.Services.AddCors(options => {
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")	//http NOT https
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// pipeline
app.UseHttpsRedirection();

app.UseCors();              //CORS

app.UseAuthentication();    //AuthN

app.UseAuthorization();     //AuthZ

app.MapControllers();

app.Run();
