using Microsoft.EntityFrameworkCore;
using Technical.Infraestructure.Context;
using Technical.Ioc.Dependencias;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Dependencias del contexto

builder.Services.AddDbContext<ProductsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NorthWindContext")));

// Dependencias del modulo Products

builder.Services.AddProductsDependency();

// Dependencias del app service

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy("ApiAllowSpecificOrigins",
        policy =>
        {
            policy
                .AllowAnyOrigin()  
                .AllowAnyHeader()   
                .AllowAnyMethod();   
        });
});

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

app.UseCors("ApiAllowSpecificOrigins");

app.Run();
