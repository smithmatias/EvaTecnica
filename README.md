# EvaluacionDev

API en .NET 8 + frontend en React/TypeScript para evaluacion tecnica.
Duracion: ~90 minutos

## Stack

**Backend**
- .NET 8 / ASP.NET Core Web API
- Entity Framework Core
- SQLite

**Frontend**
- React 19 + TypeScript
- Vite

## Estructura

```
EvaTecnica/
├── .devcontainer/
├── backend/
│   ├── Controllers/
│   ├── Interfaces/
│   ├── Services/
│   ├── Models/
│   │   ├── DTOs/
│   │   └── Entities/
│   └── Data/
└── frontend/
    └── src/
        ├── components/
        └── types.ts
```

## Fuente de datos

- SQLite local, archivo `backend/evaluaciondev.db`
- Connection string en `backend/appsettings.json`: `Data Source=evaluaciondev.db`
- El archivo **no esta versionado**: se crea solo en el primer arranque con los datos
  de ejemplo. Para volver al estado inicial, borralo y volve a levantar la API.

## Como levantarlo

Hacen falta **dos terminales**, una para cada proyecto.

Terminal 1 — API (queda en `http://localhost:5153`):

```bash
cd backend
dotnet run --launch-profile http
```

Terminal 2 — Frontend (queda en `http://localhost:5173`):

```bash
cd frontend
npm run dev
```

Swagger queda en `http://localhost:5153/swagger`.

El frontend le pega a la API a traves del proxy de Vite (`/api` → `localhost:5153`),
asi que en el codigo se usan rutas relativas: `fetch('/api/Tareas')`.

### En Codespaces

El devcontainer ya instala .NET 8 y Node 22, y corre `dotnet restore` + `npm install`
al crearse. Solo hay que abrir las dos terminales y correr los comandos de arriba.

### En local

Requisitos: .NET 8 SDK y Node 20.19+ (o 22+). Antes de la primera corrida:

```bash
cd backend && dotnet restore
cd ../frontend && npm install
```

## Endpoints

| Metodo | Ruta |
|---|---|
| GET | `/api/Tareas` |
| GET | `/api/Tareas/{id}` |
| POST | `/api/Tareas` |
| PATCH | `/api/Tareas/{id}` |
| DELETE | `/api/Tareas/{id}` |
| GET | `/api/Tareas/usuarios` |
| POST | `/api/Tareas/usuarios` |

## Nota

Hay casos intencionales en el codigo que forman parte de la evaluacion.

---

# Enunciados — Backend

## Practica

1. Actualizar una tarea devuelve 200, pero no actualiza correctamente el dato.
   Validar y corregir.

2. Intento crear un usuario con el siguiente correo: `matias@example.com`
   Pero esta dando error, no se por que. Se pide validar y corregir el error.
   En base a lo que concluyas, ¿que deberia pasar?

3. Al endpoint que trae todas las tareas, se pide filtrar el resultado para solo traer:
   - Tareas completadas
   - Tareas con una descripcion no vacia ni nula

4. Al endpoint que trae todas las tareas, se pide agregar parametros opcionales.
   Se pide poder indicarle un `usuarioId`. Lo mismo para titulo (contains).

## Teoria

1. Importacion de backup de tareas sin el campo "Completada": ¿tratamiento y riesgos?
2. ¿Que es un `IQueryable`, que particularidad tiene? ¿Como se forma y que se puede hacer con el?
3. ¿Que esta haciendo el `Select` dentro de las queries, y por que se esta implementando el DTO?

---

# Enunciados — Frontend

## Practica

1. **`src/components/ListaTareas.tsx`** — Este componente anda bien cuando todo sale bien.
   Antes de tocar nada: ¿que ve el usuario si la API tarda 4 segundos? ¿Y si esta caida?
   ¿Y si no hay ninguna tarea cargada?

2. **`src/components/AgregarTarea.tsx`** — Reporte del usuario: *"Agrego una tarea, la
   pantalla no cambia. Pero si refresco el navegador, la tarea esta. ¿Que pasa?"*

3. **Alta de usuario** — Arma un formulario para dar de alta un usuario. Pega contra
   `POST /api/Tareas/usuarios` con `{ nombre, email, activo }`. El hueco esta marcado
   en `src/App.tsx`.

## Teoria

1. Mira `src/types.ts`: ¿por que `fechaVencimiento` esta tipado como `string` si es una fecha?
2. ¿Por que validar en el front si el back tambien valida?
