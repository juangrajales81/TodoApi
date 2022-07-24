# TodoApi

Esta es la parte Back-End para la prueba técnica. Se ha utilizado Microsoft Visual Studio Community 2022 Versión 17.2.6

NOTA: Para revisar la parte Front-End, descargar el repositorio https://github.com/juangrajales81/to-do-list

Pasos para ejecutar la aplicación localmente:

1. Restaurar los paquetes NuGet. Para esta solución se han usado `Microsoft.EntityFrameworkCore.InMemory` y `Microsoft.EntityFrameworkCore.SqlServer`
	NOTA: Si se desea ejecutar la aplicación sin crear una BD, se puede descargar la rama `ef_virtual`, esta corre una BD temporal mientras la aplicación esté en ejecución.

2. Crear en (localdb)\MSSQLLocalDB una BD local llamada `ToDoList`

3. Crear una tabla llamada `TodoItems`

``` sql
USE ToDoList
CREATE TABLE TodoItems (
	id int NOT NULL IDENTITY(1, 1),
    name varchar(255),
    isComplete bit,
	PRIMARY KEY (id)
);
```

4. Ejecutar con F5 y esperar que la aplicación abra el navegador con la ruta https://localhost:7126/api/todoitems.  Esta página mostrará una información inicial, con los registros agregados por código.  