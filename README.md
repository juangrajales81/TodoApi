# TodoApi

Pasos para ejecutar la aplicación localmente:

1. Restaurar los paquetes NuGet. Para esta solución se han instalado `Microsoft.EntityFrameworkCore.InMemory` y `Microsoft.EntityFrameworkCore.SqlServer`  
2. Crear en (localdb)\MSSQLLocalDB una BD local llamada `ToDoList`
3. Crear una tabla llamada `TodoItems`

USE ToDoList
CREATE TABLE TodoItems (
	id int NOT NULL IDENTITY(1, 1),
    name varchar(255),
    isComplete bit,
	PRIMARY KEY (id)
);


