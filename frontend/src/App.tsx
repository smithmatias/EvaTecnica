import { ListaTareas } from './components/ListaTareas'
import { AgregarTarea } from './components/AgregarTarea'

export function App() {
  return (
    <main>
      <h1>EvaluacionDev</h1>

      <section>
        <h2>Tareas</h2>
        <ListaTareas />
      </section>

      <section>
        <h2>Agregar tarea</h2>
        <AgregarTarea />
      </section>

      <section>
        <h2>Alta de usuario</h2>
        {/* Ejercicio 3: aca va el formulario de alta de usuario. */}
      </section>
    </main>
  )
}
