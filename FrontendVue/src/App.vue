<script setup>
  import ListaProducto from './components/ListaProductos.vue'
</script>

<template>
  <main>
    <h1>Gestion de Productos</h1>
    <p>Bienvenido al sistema de administracion de productos.</p>
    <ListaProducto titulo="Catalogo Actual"
                   subtitulo="Datos obtenidos desde el Backend" />
  </main>
</template>

<style scoped>
  main {
    padding: 2rem;
  }
</style>
