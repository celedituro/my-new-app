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
## Patrones de diseños
- State
- Strategy

Ambos patrones fueron usados en la implementación de la lógica del cálculo de la categoría de una persona.

## Preguntas
1. ¿Qué diferencia hay entre hacer que la base de datos se encargue de filtrar información que se tiene que visualizar en el frontend y hacer el filtro directamente en el frontend sin resolverlo a nivel de la base de datos? Las bases de datos tienen gestores que se encargan de optimizar las consultas que se hacen a las mismas con el objetivo de que las respuestas sean inmediatas o se puedan brindar lo más rápido posible. Por lo tanto, hacer el filtro a nivel de las bases de datos en un sistema con abundante cantidad de información almacenada es mucho más veloz que si se hace por medio del frontend.

2. ¿Qué tipos de validaciones puede tener un sistema? ¿Dónde se deben implementar? Por un lado, están las validaciones del modelo del negocio que se hacen a nivel de backend y se refieren a validaciones propias del dominio que estamos modelando como por ejemplo si se le pide al usuario que ingrese una calificación una regla de negocio podría ser que dicha calificación sea entre 1 y 5. Y por el otro lado, están las validaciones que se encargan de chequear que el usuario ingrese bien ciertos datos que se hacen a nivel de frontend como por ejemplo si tiene que ingresar un número de teléfono, que no ingrese texto sino números.

3. ¿Qué es un ORM? Mencionar ventajas y desventajas. Es una técnica para manipular los datos almacenados en las bases de datos por medio de objetos y siguiendo el paradigma de programación orientada a objetos. Una ventaja es que permite al programador no tener que escribir consultas SQL para poder hacer operaciones básicas como las operaciones CRUD. Sin embargo, cuando las consultas son complejas, el uso de ORM puede implicar una mala performance de la aplicación por lo que es necesario que el programador conozca manipular y realizar consultas SQL.
   
4. ¿Qué es una API REST? Es una interfaz que permite la comunicación entre aplicaciones a partir de solicitudes http que tienen que cumplir una serie de condiciones. El cumplimiento de estas condicion permite mejorar la performance de la aplicación. Una de las condiciones es  separar cliente y servidor (backend y frontend) para proteger el acceso a los datos almacenados en las bases de datos.

5. ¿Cuál es la diferencias entre un test unitario y un test de integración? Mientras un test unitario valida que un objeto funcione como se esperada, un test de integración chequea que la interacción entre un conjunto de objetos sea correcta.

6. ¿Para qué se usan los mocks en los unit test? Los mocks se usan en los test unitarios cuando el objeto que se quiere evaluar depende del funcionamiento de otro objeto. Entonces se usa el mock para hacer que el objeto del cual depende nuestro objeto que está siendo testeado se comporte de la forma que esperamos. De esta forma logramos abstraernos del funcionamiento de este objeto y nos centramos en el que queremos testear.
