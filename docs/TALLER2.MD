**Taller 2: Web API, Model Binding, Model Validation e Inyección de Dependencias en .Net Core con C#**

El propósito de éste taller es crear una API REST que exponga los servicios implementados en el taller anterior, tambíen que se familiaricen con la estructura de un proyecto en .Net Core siguiendo una [arquitectura limpia](https://docs.microsoft.com/es-es/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture) así cómo conceptos del desarrollo Web en C#, tales cómo:

- [Model Binding](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-3.1).
- [Model Validation](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-3.1).
- [Inyección de dependencias](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/dependency-injection?view=aspnetcore-3.1).
- [Api Web Routing & HTTP Verbs Template](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-3.1#http-verb-templates).
- [Action Return Types](https://docs.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-3.1#actionresultt-type)
- Referencias entre proyectos


**Contexto**

Para éste taller contamos con una solución de .Net Core llamada *talleres* (talleres.sln), la cual está compuesta por 5 proyectos:

|Proyecto  |Ruta base  |Contenido  |
|---------|---------|---------|
|ApplicationCore|src/ApplicationCore|Entidades, Interfaces, Servicios y Excepciones|
|Infrastructure (Nuevo)|src/Infrastructure|Implementaciones de los repositorios que simulan la capa de datos|
|Web (Nuevo)|src/Web|Controladores Web API, Punto de acople entre Core e Infrastructure, Configuración de la aplicación de de los servicios del core para la inyección de dependencias|
|UnitTests|tests/UnitTests|Pruebas unitarias de las entidades y los servicios del Core|
|FuntionalTests (Nuevo)|tests/FunctionalTests|Pruebas funcionales del API REST|


En el siguiente diagrama, se muestra el diseño de la aplicación src/Web:

![API Web MVC](https://docs.microsoft.com/es-es/aspnet/core/tutorials/first-web-api/_static/architecture.png)

El siguiente es el catálogo de los endpoints de API REST que se deben implementar:

**Catálogo**

|API  |Descripción  |Cuerpo de la solicitud|Cuerpo de la Respuesta|
|---------|---------|---------|---------|
|GET /api/catalog|Obtiene la lista de productos del catálogo|Ninguno|Lista de [CatalogItem](../src/ApplicationCore/Entities/CatalogItem.cs)|

> [!NOTE]
> Este endpoint ya está implementado en [CatalogController](../src/Web/Controllers/Api/CatalogController.cs)

**Basket**

|API  |Descripción  |Cuerpo de la solicitud|Cuerpo de la Respuesta|
|---------|---------|---------|---------|
|GET /api/basket|Obtiene la lista de canastas|Ninguno|Lista de [Basket](../src/ApplicationCore/Entities/Basket.cs)|
|GET /api/basket/user/{id}|Obtiene la canasta de un usuario determinado. Si no existe la canasta debe crear una nueva para el usuario|Ninguno|[Basket](../src/ApplicationCore/Entities/Basket.cs)|
|GET /api/basket/user/{id}/count|Obtiene la suma de items en la canasta de un usuario determinado|Ninguno|int|
|POST /api/basket/{id}/items|Agrega un item a una canasta determinada|[CatalogItem](../src/ApplicationCore/Entities/CatalogItem.cs)|[Basket](../src/ApplicationCore/Entities/Basket.cs)|
|PUT /api/basket/{id}/items|Actualiza las canidades de los items de una canasta determinada|Lista de [QuantityModel](../src/Web/Models/QuantityModel.cs)|[Basket](../src/ApplicationCore/Entities/Basket.cs)|
|PUT /api/basket/{id}/user/{targetUser}|Transfiere una canasta de un usuario anónimo a un usuario en concreto|Ninguno|[Basket](../src/ApplicationCore/Entities/Basket.cs)|
|DELETE /api/basket/{id}|Elimina una canasta determinada|Ninguno|Ninguno|

**Order**

|API  |Descripción  |Cuerpo de la solicitud|Cuerpo de la Respuesta|
|---------|---------|---------|---------|
|Post /api/order|Crea una órden de compra|[OrderModel](../src/Web/Models/OrderModel.cs)|[Order](../src/ApplicationCore/Entities/Order.cs)|

**Respuestas HTTP**

Para cada uno de los endpoints descritos arriba se debe tener en cuenta los siguientes escenarios:


|Escenario  |HTTP Status|
|-----------|-----------|
|Operación exitosa              |200|
|Solicitud/Request inválida     |400|
|Orden/Canasta/Usuario no existe|404|
|Excepción                      |500|

==========

Al clonar el repositorio notarán que no compila, ésto es normal.  El código está incompleto a propósito y ustedes deben completarlo resolviendo las tareas que encontrarán dentro del mismo.

Las tareas a resolver los van a encontrar en forma de comentario dentro de las clases con la etiqueta de *TODO*.  Algunos comentarios van acompañados de enlaces a documentación de referencia que les puede ayudar a resolver la taréa.

Una vez resuelvan las tareas podran compilar el proyecto y ejecutar las pruebas unitarias y funcionales. Para compilar la solución pueden:


|IDE      |Pasos  |
|---------|---------|
|VS Code      |1. Abrir la terminal 
||2. desde la raíz de la solución ejecutar `dotnet build`|
|Visual Studio|Menú Compilar -> Compilar Solución :v|


Las pruebas unitarias y funcionales ya están implementadas, no se deben modificar ya que es el mecanismo para probar si resolvieron bien las tareas. Para ejecutar las pruebas pueden:

|IDE      |Pasos  |
|---------|---------|
|VS Code      |1. Abrir la terminal 
||2. desde la raíz de la solución ejecutar `dotnet test`|
|Visual Studio|Menú Prueba -> Ejecutar todas las pruebas :v|

> [!IMPORTANT]
> Revisen todo el proyecto Web, Core e Infrastructure así cómo sus respectivos archivos *.csproj* y asegúrense que todas las tareas que están marcadas con el comentario TODO estén resueltas.

Los talleres se evalúan ejecutando un pipeline de Continuous Integration que valida los puntos descritos en la **lista de chequeo**, ésto quiere decir que si falla la ejecución del pipeline la entrega no será aceptada, la nota del taller depende entéramente de ésto. Adicionalmente se realizará una revisión de código con el fin de retroalimentar al estudiante con propuestas de mejora y aclarar dudas.

Todos los cambios hechos deber quedar en su rama personal y al finalizar debe crear un **Pull Request** aputando hacia la rama `master`.  Si es su primera vez con git, revise los enlaces en [README.MD](../README.MD)

**Restricciones**

- No se deben modificar las pruebas unitarias.
- No se deben modificar las pruebas funcionales.
- No se deben crear pruebas unitarias.
- No se deben crear pruebas funcionales.
- No se deben renombar las clases, archivos, carpetas, métodos así cómo cambiar las firmas de los métodos existentes.
- Cualquier entrega, o versión de la misma, que se haga después del plazo no será tenida en cuenta.
- Para validar la fecha y hora de entrega se tendrá en cuenta únicamente la hora y fecha registradas por GitHub.

**Lista de chequeo:**

1. Implementar los controladores para las api de Basket y Order. Los Controladores deben consumir los servicios del Core.

2. Los Controladores deben usar [Model Binding](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-3.1).

3. Los Controladores deber usar [HTTP Verbs Templates](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-3.1#http-verb-templates).

4. Los Controladores debe usar [Model Validation](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-3.1).

2. Agregar las referencias faltantes a los proyectos de las diferentes capas de la aplicación en los archivos *.csproj*.

3. Configurar la [inyección de dependencias](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/dependency-injection?view=aspnetcore-3.1) en la Capa Web, se deben registrar los servicios y los repositorios.

4. Implemente los métodos de los repositorios BasketRepository y OrderRepository que están dentro de [Infrastructure](../src/Infrastructure)

5. El proyecto debe compilar sin errores.

6. El 100% de las pruebas unitarias y funcionales deben pasar.

7. Se debe crear un Pull Request con destino a la rama de **master** en GitHub.

8. El proceso de CI debe ejecutarse exitosamente (Este proceso se ejecuta automáticamente una vez se crea el Pull Request).

9. La cobertura de las pruebas unitarias debe ser de al menos 60%.