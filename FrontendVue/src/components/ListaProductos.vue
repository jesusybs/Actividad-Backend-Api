//Estructura general
<script setup>

import{ref, onMounted} from 'vue'
//crear las variables reactivas
import { ref } from 'vue'

import axios from 'axios'
const productos = ref([]) //Guarda la lista recibida desde la API
const cargango = ref(false) // Permite mostrar un mensaje mientras se realiza la solicitud
const error = ref('')//Guarda un mensaje si la API no responde
const obtenerProductos= async () =>
{
    cargango.value=true
    error.value=''

    try {

       const respuesta = await axios.get( // ESpera la respuesta de la API
           'https://localhost:5173/api/productos'
       )
       productos.value = respuesta.data //Contiene el JSON enviado por .NET core
    } catch (e){
    console.error(e)
    error.value=
    'No fue posible obtener los productos desde API'
    } finally { //Se va a ejecutar si la consulta funciona o falla
     cargango.value= false
    }
}
onMounted(() =>  {//Permite ejecutar la consulta cuando el componente ya fue montado en la interfaz
 obtenerProductos()
})

</script>
<template>
  <div class="container mt-4">
    <h2> Lista de Productos </h2>
  </div>
</template>
