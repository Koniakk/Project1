
import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

export default defineConfig({
  plugins: [react()],
  server: {
    proxy: {
      '/avia_sales': {
        target: 'http://avia_salesapi:8080',
        changeOrigin: true,
        rewrite: (path) => path
      }
    }
  }
})