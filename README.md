# EvaluacionDev

API en .NET 8 + frontend en React/TypeScript.
Esta guia explica como levantar los dos proyectos.

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
- El archivo **no esta versionado**: se crea solo en el primer arranque, con datos de ejemplo

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

## Si algo no arranca

- **La API no levanta / puerto 5153 ocupado:** revisar que no haya otra instancia corriendo.
- **El front carga pero no trae datos:** falta levantar la API. El front le pega a traves del
  proxy, asi que sin backend las listas quedan vacias.
- **Volver al estado inicial de los datos:** parar la API, borrar `backend/evaluaciondev.db`
  y volver a levantarla.
