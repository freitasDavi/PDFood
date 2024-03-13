<script setup lang="ts">
import InputText from 'primevue/inputtext';
import { defineModel } from 'vue';

const barCode = defineModel<string>('bar')
const productName = defineModel<string>('product')

</script>


<template>
    <div class="flex gap-2">
        <InputText type="text" v-model="barCode" />
        <InputText type="text" v-model="productName" />
    </div>
</template>