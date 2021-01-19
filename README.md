# Ejemplo de API restful con .NET 5
Pequeño ejemplo compuesto de una APiRestful, con un servicio (ProductController) que gestiona productos de una base de datos, a través de los verbos de HttpGet, HttpPost, HttpPut y HttpDelete. El ejemplo también garantiza que funcionen correctamente a través de test de integración.

Los puntos tratados en el ejemplo son:
* ApiRestful.Service: servicio API que provee los métodos de comunicación con los productos de la base de datos.
* ApiRestful.Test: aplicación de test que testea el servicio ApiRestful.Service

## Comenzando 🚀

En este ejemplo me he apoyado en las siguientes librerías:
* **Autodocumentación de la API restful:** Mediante [Swagger](https://swagger.io/)
* **Librería de testing:** Mediante [XUnit](https://xunit.net/)
* **Sintaxis intuitiva para testing:** Mediante [FluentAssertions](https://fluentassertions.com/)

Otros puntos de interés:
* **Herramienta de Testing:** Como herramienta externa de testeto, aconsejo [Postman](https://www.postman.com/)
* **Mapeo de objetos:** Mediante [AutoMapper](https://automapper.org/)
* **Logging:** Mediante [Serilog](https://serilog.net/)


### Pre-requisitos 📋

Como herramientas de desarrollo necesitarás:
* Visual Studio 2019 (con la versión para .NET 5)
* SQL Server (con la versión Express es suficiente)

```
Nota: Visual Studio Code también valdría
```

### Instalación 🔧

Una vez descargado el código, el primer paso es configurar la base de datos. Para ello debes:
* Crear una base de datos SQL
* Crear la tabla [Product]. En el script ApiRestful.Service/SQL/SQLCreateProductTable.sql tienes cómo hacerlo.
* Configurar el ConnectionString, en la clase InventoryContext
* Si quieres introducir más productos, puedes ejecutar el test unitario IntegrationProductTest.Api_Product_Post_Product

## Ejecutando la aplicación ⚙️

Si todo ha ido bien, deberás:
* Configurar el proyecto ApiRestful.Service como proyecto principal.
* Si ejecutas Visual Studio, deberá salir la auto-documentación de Swagger con ejemplos.
* También podrás ejecutar los test de integración de ApiRestful.Test que testean ApiRestful.Service.

## Estado de la compilación ⚙️
Este proyecto utiliza las Actions de Integración Continua de Github. Espero que el estado siga siendo verde:
![CI](https://github.com/davidsantes/ApiRestfulSample/workflows/CI/badge.svg)

Por otro lado, si quiesres consultar cómo hacer la integración, te aconsejo que veas el archivo dotnet.yml, o para más información:
* [Fixedbuffer](https://www.fixedbuffer.com/herramientas-de-desarollo-github-actions-como-ci-para-net-core/) - Herramientas de desarollo: Github Actions como CI para .Net

### ¿Qué falta? 🔩

Muchísimas cosas. Desde un testeo completo de todos los métodos, pasando por hacer una estructura "digna" en ApiRestful.Service, o implementar tokens con JWT, por ejemplo.

## Construido con 🛠️

* [Microsoft Visual Studio Community 2019](https://visualstudio.microsoft.com/es/vs/) - IDE  de desarrollo
* [SQL Server Management Studio](https://docs.microsoft.com/es-es/sql/?view=sql-server-ver15/) - IDE de base de datos
* [Resharper](https://www.jetbrains.com/es-es/resharper/) - Extensión del IDE VS para optimizar el desarrollo

## Versionado 📌

Usado [Git](https://git-scm.com//) para el versionado. Por ahora, no existen diferentes versiones disponibles. Si en un futuro existieran, estarían en los diferentes tags que se crearían.

## Autores ✒️

* **David Santesteban** - *Trabajo Inicial* - [davidsantes](https://github.com/davidsantes)

## Agradecimientos 🎁

* A cualquiera que me invite a una cerveza 🍺. 
