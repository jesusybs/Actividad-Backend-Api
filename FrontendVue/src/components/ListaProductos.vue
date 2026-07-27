<script setup>
  import { ref, onMounted } from 'vue'
  import axios from 'axios'

  // Recibimos las props del padre
  defineProps({
    titulo: String,
    subtitulo: String
  })

  const productos = ref([])
  const cargando = ref(false)
  const error = ref('')

  const obtenerProductos = async () => {
    cargando.value = true
    try {
      const respuesta = await axios.get('https://localhost:5208/api/producto')
      productos.value = respuesta.data
    } catch (e) {
      error.value = 'Error al cargar productos'
    } finally {
      cargando.value = false
    }
  }

  onMounted(obtenerProductos)
</script>

<template>
  <div class="container mt-4">
    <h2>{{ titulo }}</h2>
    <p>{{ subtitulo }}</p>

    <div v-if="cargando">Cargando...</div>
    <ul v-else>
      <li v-for="p in productos" :key="p.id">{{ p.nombre }}</li>
    </ul>
  </div>
</template>
