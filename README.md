# PeopleApi

## Preparación del repositorio
```
git clone https://github.com/celedituro/my-new-app.git
```

## Ejecutación de la aplicación
### Paso 1 ### 
Descargar todas las dependencias necesarias para ejecutar la aplicación:
```
dotnet build
```

### Paso 2 ### 
Para conectar la aplicación a una base de datos local en "DefaultConnection" del archivo appsetting.Development.json ingresar los datos correspondientes.

### Paso 3 ### 
Crear la tabla de personas localmente a partir de Entity Framework:
```
dotnet ef update database
```

### Paso 4 ### 
Ejecutar la aplicación:
```
dotnet run
```

### Paso 5 ### 
Ejecutar las pruebas:
```
cd Tests
```
```
dotnet test
```
## Preguntas
1. ¿Qué diferencia hay entre hacer que la base de datos se encargue de filtrar información que se tiene que visualizar en el frontend y hacer el filtro directamente en el frontend sin resolverlo a nivel de la base de datos?

2. ¿Qué tipos de validaciones puede tener un sistema? ¿Dónde se deben implementar?

3. ¿Qué es un ORM? Mencionar ventajas y desventajas.

4. Diferencias entre: cliente de BD vs driver de conexión de BD vs motor de base de datos.  Dar ejemplos.
   
5. ¿Qué es una API REST?

6. ¿Cuál es la diferencias entre un test unitario y un test de integración?

7. ¿Para qué se usan los mocks en los unit test?
