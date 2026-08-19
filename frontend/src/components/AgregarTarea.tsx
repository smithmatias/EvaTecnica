import { useEffect, useState, type FormEvent } from 'react'
import type { Tarea, Usuario } from '../types'

export function AgregarTarea() {
  const [tareas, setTareas] = useState<Tarea[]>([])

  useEffect(() => {
    fetch('/api/Tareas')
      .then(res => res.json())
      .then(data => setTareas(data))
  }, [])

  function agregarTarea(nueva: Tarea) {
    tareas.push(nueva)
    setTareas(tareas)
  }

  return (
    <>
      <FormularioTarea onTareaCreada={agregarTarea} />
      <ul>
        {tareas.map(t => (
          <li key={t.id}>{t.titulo}</li>
        ))}
      </ul>
    </>
  )
}

function FormularioTarea({ onTareaCreada }: { onTareaCreada: (tarea: Tarea) => void }) {
  const [titulo, setTitulo] = useState('')
  const [usuarioId, setUsuarioId] = useState(1)
  const [usuarios, setUsuarios] = useState<Usuario[]>([])

  useEffect(() => {
    fetch('/api/Tareas/usuarios')
      .then(res => res.json())
      .then(data => setUsuarios(data))
  }, [])

  async function handleSubmit(e: FormEvent) {
    e.preventDefault()
    setTitulo('')

    const res = await fetch('/api/Tareas', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        titulo,
        descripcion: null,
        fechaVencimiento: null,
        usuarioId,
      }),
    })

    const creada: Tarea = await res.json()
    onTareaCreada(creada)
  }

  return (
    <form onSubmit={handleSubmit}>
      <input
        value={titulo}
        onChange={e => setTitulo(e.target.value)}
        placeholder="Titulo de la tarea"
      />
      <select value={usuarioId} onChange={e => setUsuarioId(Number(e.target.value))}>
        {usuarios.map(u => (
          <option key={u.id} value={u.id}>
            {u.nombre}
          </option>
        ))}
      </select>
      <button type="submit">Agregar</button>
    </form>
  )
}
