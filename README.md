# EvaluacionDev

API de ejemplo en .NET 8 para evaluacion tecnica.
Duración: ~90 minutos

## Stack

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQLite

## Estructura

- Controllers
- Interfaces
- Services
- Models
  - DTOs
  - Entities
- Data

## Fuente de datos

- SQLite local
- Archivo: evaluaciondev.db
- Connection string en appsettings.json: Data Source=evaluaciondev.db

## Instalar y levantar

1. Restaurar paquetes

```powershell
dotnet restore
```

2. Compilar

```powershell
dotnet build
```

3. Ejecutar

```powershell
dotnet run
```

4. Abrir Swagger en la URL indicada por consola (ej: http://localhost:5153/swagger)

## Endpoints actuales

- GET /api/Tareas
- GET /api/Tareas/{id}
- DELETE /api/Tareas/{id}
- PATCH /api/Tareas/{id}
- POST /api/Tareas/usuarios

## Nota

- Hay casos intencionales en el código que forman parte de la evaluación.

## Enunciados - Práctica

1. Actualizar una tarea devuelve 200, pero no actualiza correctamente el dato. Validar y corregir.

2. Intento crear un usuario con el siguiente correo:
   matias@example.com
   Pero está dando error, no se por qué. Se pide validar y corregir el error.
   En base a lo que concluyas, qué debería pasar?

3. Al endpoint que trae todas las tareas, se pide filtrar el resultado para sólo traer:

- Tareas completadas
- Tareas con una descripción no vacía ni nula

4. Al endpoint que trae todas las tareas, se pide agregar parámetros opcionales.
   Se pide poder indicarle un usuarioId para que, si se lo mando, me traiga únicamente las tareas de ese userId.
   Lo mismo para Título. Se pide que si le paso un parámetro de Título, busque los títulos que contengan lo que envié.

## Enunciados - Teoría

1. Necesitamos hacer una importación de un backup de tareas que recuperamos.
   Está incompleto: Nos falta el campo "Completada" para las tareas.
   Qué tratamiento o aproximación podrías sugerir para tratar los datos y poder importarlos? Qué riesgos hay?

2. Qué es un IQueryable, qué particularidad tiene?

3. Qué está haciendo el Select dentro de las queries, y por qué se está implementando el DTO?
