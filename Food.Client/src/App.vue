<script setup lang="ts">

import Button from 'primevue/button';
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';
import { ref } from 'vue';
import { Product } from './types/Product';
import Filters from './modules/Product/Components/Filters/Filters.vue';

const filterBarCode = ref<string>('')
const filterProductName = ref<string>('')

const data = ref<Product[]>([
  {
    id: 1,
    barCode: "123",
    imageUrl: "321",
    price: 10,
    productCode: 1
  },
  {
    id: 2,
    barCode: "123",
    imageUrl: "321",
    price: 20,
    productCode: 1
  },
  {
    id: 3,
    barCode: "123",
    imageUrl: "321",
    price: 30,
    productCode: 1
  }
])

const testDefineModel = () => {
  console.log(filterBarCode.value)
  console.log(filterProductName.value)
}

</script>

<template>
  <div class="bg-emerald-500 w-full h-screen flex flex-col items-center justify-center">
    <h1 class="text-white text-4xl font-bold ">Olá P&D</h1>
    <div class="w-[43%] flex justify-between items-center">
      <div class="flex gap-2 my-4 text-white">
        <Filters v-model:bar="filterBarCode" v-model:product="filterProductName" />
        <Button icon="pi pi-search" aria-label="Pesquisar"  type="button" @click="testDefineModel" />
      </div>
      <Button label="Novo" />
    </div>
    <DataTable :value="data" style="min-width: 50rem">
      <Column field="id" header="Id" style="width: 25%"></Column>
      <Column field="barCode" header="barCode" style="width: 25%"></Column>
      <Column field="price" header="price" style="width: 25%" :sortable="true"></Column>
      <Column field="productCode" header="productCode" style="width: 25%"></Column>
    </DataTable>
  </div>
</template>
