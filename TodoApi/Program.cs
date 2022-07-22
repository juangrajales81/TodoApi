using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "TestPolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                    .WithMethods("GET", "POST", "PUT", "DELETE").WithHeaders("content-type");
        });
});

var app = builder.Build();

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
