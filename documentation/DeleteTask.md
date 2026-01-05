# Documentación del Endpoint DeleteTask (DELETE)

## Descripción

El método `DeleteTask` permite eliminar una tarea existente del sistema mediante una solicitud HTTP DELETE. Se debe proporcionar el identificador de la tarea (`id`) que se desea eliminar.

## Ruta

```
DELETE /api/task/{id}
```

## Parámetros

- **id** (int, requerido): Identificador único de la tarea a eliminar.

## Respuestas

- **204 No Content**: La tarea fue eliminada exitosamente. No se devuelve contenido en la respuesta.
- **404 Not Found**: No se encontró una tarea con el id proporcionado.
- **500 Internal Server Error**: Ocurrió un error inesperado en el servidor.

## Ejemplo de solicitud

```
DELETE /api/task/1
```

## Ejemplo de respuesta exitosa

```
Status: 204 No Content
```

## Notas

- Si la tarea no existe, se devuelve un mensaje indicando que no fue encontrada.
- Si ocurre un error durante la eliminación, se devuelve un mensaje de error con el detalle del problema.
