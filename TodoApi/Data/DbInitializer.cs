using Microsoft.EntityFrameworkCore;
using TodoApi.Models;


namespace TodoApi.Data
{
    public static class DbInitializer
    {
        public static void Initilize(IServiceProvider serviceProvider)
        {
            using (var context = new TodoContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TodoContext>>()))
            {

                // Si ya existe TodoItems la BD ya ha sido creada
                if (context.TodoItems.Any())
                {
                    return;
                }

                var todoItems = new TodoItem[]
                {
                    new TodoItem{Name="Ir de compras",IsComplete=false},
                    new TodoItem{Name="Pagar impuestos",IsComplete=false},
                    new TodoItem{Name="Pasear al perro",IsComplete=false},
                    new TodoItem{Name="Reparar el PC",IsComplete=false},
                    new TodoItem{Name="Realizar la prueba técnica",IsComplete=false}
                };

                foreach (TodoItem item in todoItems)
                {
                    context.TodoItems.Add(item);
                }

                context.SaveChanges();

            }
        }

    }
}
