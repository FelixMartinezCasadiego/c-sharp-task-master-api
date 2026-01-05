# Documentación del Endpoint UpdateTask (PUT)

## Descripción

El método `UpdateTask` permite actualizar una tarea existente en el sistema a través de una solicitud HTTP PUT. Se debe proporcionar el identificador de la tarea (`id`) y un objeto con los nuevos datos de la tarea (`TaskInsert`).

## Ruta

```
PUT /api/task/{id}
```

## Parámetros

- **id** (int, requerido): Identificador único de la tarea a actualizar.
- **taskInsert** (objeto, requerido): Objeto con los nuevos datos de la tarea.
  - **Title** (string, requerido): Nuevo título de la tarea. No puede estar vacío ni ser nulo.
  - **Description** (string, requerido): Nueva descripción de la tarea. No puede estar vacía ni ser nula.

## Respuestas

- **200 OK**: Devuelve la tarea actualizada si la operación fue exitosa.
- **400 Bad Request**: Si el título o la descripción están vacíos o son nulos.
- **404 Not Found**: Si no se encuentra la tarea con el id proporcionado.
- **500 Internal Server Error**: Si ocurre un error inesperado en el servidor.

## Ejemplo de solicitud

```
PUT /api/task/1
Content-Type: application/json

{
  "title": "Nuevo título",
  "description": "Nueva descripción"
}
```

## Ejemplo de respuesta exitosa

```
{
  "id": 1,
  "title": "Nuevo título",
  "description": "Nueva descripción",
  "createdAt": "2026-01-05T12:00:00",
  "updatedAt": "2026-01-05T12:05:00",
  "isCompleted": false
}
```

## Notas

- El campo `updatedAt` se actualiza automáticamente con la fecha y hora actual al modificar la tarea.
- Si la tarea no existe, se devuelve un mensaje indicando que no fue encontrada.
- Si los campos requeridos están vacíos o nulos, se devuelve un mensaje de error específico.
