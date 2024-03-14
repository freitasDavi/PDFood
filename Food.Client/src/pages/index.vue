<script setup lang="ts">
import Button from 'primevue/button';
import { ref, onMounted } from 'vue';
import { Product } from '../types/Product';
import Filters from '../modules/Product/Components/Filters/Filters.vue';
import Modal from '../modules/Product/Components/Modal/Modal.vue';
import Table from '../modules/Product/Components/Table/Table.vue';
import { api } from '../utils/api';

const filterBarCode = ref<string>('')
const filterProductName = ref<string>('')
const modalVisible = ref<boolean>(false);

const selectedProduct = ref<Product>({
    barCode: "",
    id: 0,
    imageUrl: "",
    price: 0,
    name: "",
    image: ""
})

const data = ref<Product[]>([])

const mock = [
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
]

const onSubmitForm = async () => {
  

  try {
    if (!selectedProduct.value.id) {
      const response = await api.post('product', selectedProduct.value);
    } else {
      const response = await api.put(`product/${selectedProduct.value.id}`, selectedProduct.value);
    }
    resetProductForm()

    fetchData();

  } catch (err) {
    console.error(err);
  }

  modalVisible.value = false;
}

const fetchData = async () => {
  var url = "product";

  if (filterBarCode.value) url += `?barCode=${filterBarCode.value}`;

  if (filterProductName.value) url += `?name=${filterProductName.value}`;

  const response = await api.get(url);

  if (response.status == 200) {
    data.value = response.data;
  }
}

const editProduct = (editP: Product) => {
  selectedProduct.value = {
    barCode: editP.barCode,
    id: editP.id,
    imageUrl: editP.imageUrl,
    price: editP.price,
    name: editP.name,
    image: editP.image
  }

  modalVisible.value = true;
}

const resetProductForm = () => {
  selectedProduct.value = {
    barCode: "",
    id: 0,
    imageUrl: "",
    price: 0,
    name: "",
    image: ""
  }
}

const clearFilters = () => {
  filterBarCode.value = '';
  filterProductName.value = '';
  fetchData();
}


onMounted(() => {
  fetchData();
})

</script>

<template>
    <main class="bg-slate-100 w-full h-screen flex items-center justify-center">
    <div class="w-3/4 flex flex-col items-center justify-center">
      <h1 class="text-slate-700 text-4xl font-bold ">Olá P&D</h1>
      <div class="w-full flex justify-between items-center">
        <div class="flex gap-2 my-4 text-white">
          <Filters v-model:bar="filterBarCode" v-model:product="filterProductName" />
          <Button icon="pi pi-search" aria-label="Pesquisar"  type="button" @click="fetchData" />
          <Button icon="pi pi-eraser" aria-label="Limpar filtros"  type="button" @click="clearFilters"/>
        </div>
        <Button label="Novo" @click="modalVisible = true" />
      </div>
      <Table :data="data" @edit-product="editProduct" />
    </div>
    <Modal v-model:visible="modalVisible" v-model="selectedProduct" @submit-product-form="onSubmitForm" />
  </main>
</template>