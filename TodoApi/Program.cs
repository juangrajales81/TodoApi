using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Data;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();

// Esta Línea de código la usaba temporalmente antes de usar una bd local
//builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));

builder.Services.AddDbContext<TodoContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("ToDoListConnection")));


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "TestPolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                    .WithMethods("GET", "POST", "PUT", "DELETE").WithHeaders("content-type", "Access-Control-Allow-Origin");
        });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    DbInitializer.Initilize(services);
}

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
        
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
