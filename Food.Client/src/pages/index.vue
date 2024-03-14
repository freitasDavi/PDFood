<script setup lang="ts">
import Button from 'primevue/button';
import { ref } from 'vue';
import { Product } from '../types/Product';
import Filters from '../modules/Product/Components/Filters/Filters.vue';
import Modal from '../modules/Product/Components/Modal/Modal.vue';
import Table from '../modules/Product/Components/Table/Table.vue';

const filterBarCode = ref<string>('')
const filterProductName = ref<string>('')
const modalVisible = ref<boolean>(false);

const selectedProduct = ref<Product>({
    barCode: "",
    id: 0,
    imageUrl: "",
    price: 0,
    name: ""
})

const data = ref<Product[]>([
  {
    id: 1,
    barCode: "123",
    imageUrl: "321",
    price: 10,
    name: "Arroz"
  },
  {
    id: 2,
    barCode: "123",
    imageUrl: "321",
    price: 20,
    name: "Feijão"
  },
  {
    id: 3,
    barCode: "123",
    imageUrl: "321",
    price: 30,
    name: "Macarrão"
  }
])

const onSubmitForm = () => {
  console.log(selectedProduct.value);
}

</script>

<template>
    <main class="bg-slate-100 w-full h-screen flex items-center justify-center">
    <div class="w-3/4 flex flex-col items-center justify-center">
      <h1 class="text-slate-700 text-4xl font-bold ">Olá P&D</h1>
      <div class="w-full flex justify-between items-center">
        <div class="flex gap-2 my-4 text-white">
          <Filters v-model:bar="filterBarCode" v-model:product="filterProductName" />
          <Button icon="pi pi-search" aria-label="Pesquisar"  type="button" @click="onSubmitForm" />
        </div>
        <Button label="Novo" @click="modalVisible = true" />
      </div>
      <Table :data="data" />
    </div>
    <Modal v-model:visible="modalVisible" v-model="selectedProduct" @submit-product-form="onSubmitForm" />
  </main>
</template>