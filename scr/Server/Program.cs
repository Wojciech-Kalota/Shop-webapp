using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add Db Context
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("TestingConnectionString")));

// Configure Services
builder.Services.AddTransient<ProductsService>();
builder.Services.AddTransient<CommentsService>();

// Nswag
builder.Services.AddOpenApiDocument();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient",
        policy => policy
            .WithOrigins("https://localhost:7129") // your Blazor client port!
            .AllowAnyMethod()
            .AllowAnyHeader());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseOpenApi(); // Serves the OpenAPI spec
    app.UseSwaggerUi(); // Serves Swagger UI
}

app.UseCors("AllowBlazorClient");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
