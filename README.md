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
## Patrones de diseño
- State
- Strategy

Ambos patrones fueron usados en la implementación de la lógica de la asignación de la categoría de una persona.

## Preguntas
1. ¿Qué diferencia hay entre hacer que la base de datos se encargue de filtrar información que se tiene que visualizar en el frontend y hacer el filtro directamente en el frontend sin resolverlo a nivel de la base de datos? Las bases de datos tienen gestores que se encargan de optimizar las consultas que se hacen a las mismas con el objetivo de que las respuestas sean rápidas. Por lo tanto, hacer el filtro a nivel de las bases de datos en un sistema que cuenta con un gran volumen de información almacenada es mucho más veloz que si se hace por medio de un filtro a nivel de frontend.
    
2. ¿Qué tipos de validaciones puede tener un sistema? ¿Dónde se deben implementar? Por un lado, están las validaciones de negocio que se hacen a nivel de backend y tienen que ver con cuestiones propas del negocio que estmos modelando como por ejemplo: si se le pide al usuario que ingrese una calificación, una regla de negocio podría ser que dicha calificación sea entre 1 y 5. Y por el otro lado, están las validaciones de lo que ingresa el usuario, que se hacen a nivel de frontend y se encargan de chequear que lo que ingrese cumpla con ciertos requermientos básicos como por ejemplo: si se le pide que ingrese un número de teléfono, que no ingrese letras sino números.

3. ¿Qué es un ORM? Mencionar ventajas y desventajas. Es una técnica para manipular los datos almacenados en las bases de datos por medio de objetos y siguiendo el paradigma de programación orientada a objetos. Una ventaja es que permite al programador no tener que escribir consultas SQL para poder hacer operaciones básicas como las operaciones CRUD. Sin embargo, cuando las consultas son complejas, el uso de ORM puede implicar una mala performance de la aplicación por lo que es necesario que el programador pueda realizar consultas SQL.

4. Mencionar diferencias entre cliente de bd, un driver de bd y un motor de bd.
    - **Cliente**: es una aplicación de frontend que realiza consultas a una base de datos. Ejemplo: aplicación Nodejs.
    - **Driver**: es un programa, dependencia o librería que permite la comunicación entre un cliente y un motor de base de datos. Ejemplo: driver que permite la comunicación entre Nodejs y PostgresSQL.
    - **Motor**: es un componente de software que se encarga de manipular (crear, leer, eliminar) los datos de una base de datos. Ejemplo: Oracle, PostgreSQL, MySql.

5. ¿Qué es una API REST? Es una interfaz que permite la comunicación entre aplicaciones, a partir de solicitudes http que tienen que cumplir una serie de condiciones. El cumplimiento de estas condiciones permite mejorar la performance de la aplicación. Una de las condiciones es  separar cliente y servidor (backend y frontend) para proteger el acceso a los datos almacenados en las bases de datos.

6. ¿Cuál es la diferencias entre un test unitario y un test de integración? Mientras un test unitario valida que un objeto funcione como se espera, un test de integración chequea que la interacción entre un conjunto de objetos sea correcta.

7. ¿Para qué se usan los mocks en los unit test? Se utilizan para predecir el comportamiento de un servicio externo (tiempo, clima). Cuando el objeto que se quiere evaluar depende de un servicio externo como el clima o el tiempo, los mocks en los tests son necesarios para que los resultados de los tests no varíen dependiendo del clima ya que su comportamiento no es determinístico y varía continuamente.
