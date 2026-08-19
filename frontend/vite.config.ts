import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// El proxy corre del lado del servidor de Vite: el navegador solo habla con el
// puerto 5173. Por eso el backend no necesita CORS y en Codespaces no hace falta
// hacer publico el puerto 5153.
export default defineConfig({
  plugins: [react()],
  server: {
    port: 5173,
    proxy: {
      '/api': {
        target: 'http://localhost:5153',
        changeOrigin: true,
      },
    },
  },
})
