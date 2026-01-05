# Documentación del método CreateTask

## Descripción

El método `CreateTask` es un endpoint HTTP POST del controlador `TaskController` en la API TaskMaster. Permite crear una nueva tarea a partir de los datos enviados en el cuerpo de la solicitud.

## Ruta

```
POST /api/task
```

## Parámetros de entrada

- **taskInsert** (`Models.TaskInsert`): Objeto recibido en el cuerpo de la solicitud, que debe contener los siguientes campos:
  - `Title` (string): Título de la tarea. No puede estar vacío ni ser nulo.
  - `Description` (string): Descripción de la tarea. No puede estar vacía ni ser nula.

## Validaciones

- Si el título está vacío o es nulo, retorna un error 400 (Bad Request) con el mensaje: "El título de la tarea no puede estar vacío."
- Si la descripción está vacía o es nula, retorna un error 400 (Bad Request) con el mensaje: "La descripción de la tarea no puede estar vacía."

## Proceso de creación

- Se genera un nuevo ID para la tarea sumando 1 al ID máximo existente.
- Se asignan las fechas de creación y actualización con la fecha y hora actual.
- La tarea se marca como no completada por defecto.
- Se asignan el título y la descripción recibidos.

## Respuestas

- **200 OK**: Retorna la tarea creada en formato JSON si la operación es exitosa.
- **400 Bad Request**: Si el título o la descripción son inválidos.
- **500 Internal Server Error**: Si ocurre una excepción al guardar la tarea, retorna el mensaje de error interno.

## Ejemplo de solicitud

```http
POST /api/task
Content-Type: application/json

{
  "title": "Comprar víveres",
  "description": "Comprar leche, pan y huevos."
}
```

## Ejemplo de respuesta exitosa

```json
{
  "id": 5,
  "title": "Comprar víveres",
  "description": "Comprar leche, pan y huevos.",
  "createdAt": "2026-01-05T10:30:00",
  "updatedAt": "2026-01-05T10:30:00",
  "isCompleted": false
}
```

## Notas

- El método utiliza un almacenamiento en memoria (`TaskDataStore.Current.Tasks`).
- Es importante manejar correctamente los errores para evitar respuestas inesperadas al cliente.
