export interface Tarea {
  id: number
  titulo: string
  descripcion: string | null
  completada: boolean
  fechaCreacion: string
  fechaVencimiento: string | null
  usuarioId: number
}

export interface Usuario {
  id: number
  nombre: string
  email: string
  activo: boolean
  fechaAlta: string
}
