<script setup lang="ts">
import InputText from 'primevue/inputtext';
import { defineModel } from 'vue';

const barCode = defineModel<string>('bar')
const productName = defineModel<string>('product')

</script>


<template>
    <div class="flex gap-2">
        <InputText placeholder="Código de barras" type="text" v-model="barCode" />
        <InputText placeholder="Nome do produto" type="text" v-model="productName" />
    </div>
</template>