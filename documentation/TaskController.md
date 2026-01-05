# Documentación de TaskController.cs

## Descripción General

El archivo `TaskController.cs` define el controlador principal de la API para la gestión de tareas en el proyecto **TaskMasterAPI**. Este controlador expone endpoints HTTP para interactuar con la colección de tareas, permitiendo obtener todas las tareas o una tarea específica por su identificador.

## Ubicación

- Ruta: `/Controllers/TaskController.cs`

## Funcionalidad

`TaskController` es un controlador API de ASP.NET Core que proporciona los siguientes endpoints:

- `GET /api/task` — Devuelve la lista completa de tareas almacenadas.
- `GET /api/task/{id}` — Devuelve una tarea específica según su identificador (`id`). Si la tarea no existe, retorna un error 404.

## Integración con el resto del sistema

- **Modelo de datos:** Utiliza la clase `Task` definida en `/Models/Task.cs`, que representa la estructura de una tarea (id, título, descripción, estado, fechas de creación y actualización).
- **Almacenamiento de datos:** Accede a la lista de tareas a través de la clase singleton `TaskDataStore` ubicada en `/Services/TaskDataStore.cs`. Esta clase mantiene una colección en memoria de objetos `Task` y expone la propiedad estática `Current` para acceder a la instancia global.

## Flujo de funcionamiento

1. El controlador recibe una solicitud HTTP (GET) en la ruta correspondiente.
2. Utiliza `TaskDataStore.Current.Tasks` para acceder a la lista de tareas.
3. Devuelve la información solicitada en formato JSON, utilizando los métodos de respuesta estándar de ASP.NET Core (`Ok`, `NotFound`).

## Ejemplo de uso

- Obtener todas las tareas:
  - `GET /api/task`
- Obtener una tarea específica (por ejemplo, con id=2):
  - `GET /api/task/2`

## Respuestas posibles

- **200 OK:** Solicitud exitosa, devuelve la(s) tarea(s) solicitada(s).
- **404 Not Found:** La tarea solicitada no existe.

## Diagrama de relación

```
[Cliente HTTP]
     |
     v
[TaskController.cs] <----> [TaskDataStore.cs] <----> [Task.cs]
```

- `TaskController` expone los endpoints y gestiona las solicitudes.
- `TaskDataStore` almacena y gestiona la lista de tareas en memoria.
- `Task` define la estructura de cada tarea.

---

**Autor:** GitHub Copilot
**Fecha:** 5 de enero de 2026
