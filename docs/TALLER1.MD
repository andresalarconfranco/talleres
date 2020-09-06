**Taller 1: Introducción al desarrollo en .Net Core con C#**

El propósito de éste taller es que se familiaricen con la estructura básica de un proyecto en .Net Core y conceptos básicos de la programación en C#, tales cómo:

- Declaración y asignación de variables
- Definición de Tipos de datos personalizados
- Herencia, encapsulación y polimorfismo
- Excepciones
- Métodos y parámetros
- Espacios de nombres (Namespaces)

**Contexto**

Para éste taller contamos con una solución de .Net Core llamada *talleres* (talleres.sln), la cual está compuesta por 2 proyectos:

|Proyecto  |Ruta base  |Contenido  |
|---------|---------|---------|
|ApplicationCore|src/ApplicationCore|Entidades, Interfaces, Servicios y Excepciones|
|UnitTests|tests/UnitTests|Pruebas unitarias de las entidades y los servicios del Core|

Al clonar el repositorio notarán que no compila, ésto es normal.  El código está incompleto a propósito y ustedes deben completarlo resolviendo las tareas que encontrarán dentro del mismo.

Las tareas a resolver los van a encontrar en forma de comentario dentro de las clases con la etiqueta de *TODO*.  Algunos comentarios van acompañados de enlaces a documentación de referencia que les puede ayudar a resolver la taréa. Van a trabajar únicamente sobre el Core.

Una vez resuelvan las tareas podran compilar el proyecto y ejecutar las pruebas unitarias. Para compilar la solución pueden:


|IDE      |Pasos  |
|---------|---------|
|VS Code      |1. Abrir la terminal 
||2. desde la raíz de la solución ejecutar `dotnet build`|
|Visual Studio|Menú Compilar -> Compilar Solución :v|


Las pruebas unitarias ya están implementadas, no se deben modificar ya que es el mecanismo para probar si resolvieron bien las tareas. Para ejecutar las pruebas unitarias pueden:

|IDE      |Pasos  |
|---------|---------|
|VS Code      |1. Abrir la terminal 
||2. desde tests/UnitTests ejecutar `dotnet test`|
|Visual Studio|Menú Prueba -> Ejecutar todas las pruebas :v|

> [!IMPORTANT]
> Revisen todo el proyecto Core y asegúrense que todas las tareas que están marcadas con el comentario TODO estén resueltas.

Los talleres se evalúan ejecutando un pipeline de Continuous Integration que valida los puntos descritos en la **lista de chequeo**, ésto quiere decir que si falla la ejecución del pipeline la entrega no será aceptada, la nota del taller depende entéramente de ésto. Adicionalmente se realizará una revisión de código con el fin de retroalimentar al estudiante con propuestas de mejora y aclarar dudas.

Todos los cambios hechos deber quedar en su rama personal y al finalizar debe crear un **Pull Request** aputando hacia la rama `master`.  Si es su primera vez con git, revise los enlaces en [README.MD](../README.MD)

**Restricciones**

- No se deben modificar las pruebas unitarias
- No se deben crear pruebas unitarias
- No se deben renombar las clases, archivos, carpetas, configuraciones, métodos así cómo cambiar las firmas de los métodos existentes.
- Cualquier entrega, o versión de la misma, que se haga después del plazo no será tenida en cuenta.
- Para validar la fecha y hora de entrega se tendrá en cuenta únicamente la hora y fecha registradas por GitHub.

**Lista de chequeo:**

1. Los servicios deben implementar sus repectivas interfaces:

- IOrderService -> OrderService
- IBasketService -> BasketService

2. Importar las entidades usando la sentencia `using` en las interfaces y en los servicios, así cómo cualquier otra clase que sea necesaria.

3. Implementar la lógica de negocio dentro de cáda método público de los servicios.

4. El proyecto debe compilar sin errores.

5. El 100% de las pruebas unitarias deben pasar.

6. Se debe crear un Pull Request con destino a la rama de **master** en GitHub.

7. El proceso de CI debe ejecutarse exitosamente (Este proceso se ejecuta automáticamente una vez se crea el Pull Request).

8. La cobertura de las pruebas unitarias debe ser de al menos 60%.