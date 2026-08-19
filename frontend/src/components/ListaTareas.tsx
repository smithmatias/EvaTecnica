import { useEffect, useState } from 'react'
import type { Tarea } from '../types'

export function ListaTareas() {
  const [tareas, setTareas] = useState<Tarea[]>([])

  useEffect(() => {
    fetch('/api/Tareas')
      .then(res => res.json())
      .then(data => setTareas(data))
  }, [])

  return (
    <ul>
      {tareas.map(t => (
        <li key={t.id}>{t.titulo}</li>
      ))}
    </ul>
  )
}
