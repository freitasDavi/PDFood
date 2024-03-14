<script setup lang="ts">
import Button from 'primevue/button';
import { ref, onMounted, computed } from 'vue';
import { PaginatedProduct, Product } from '../types/Product';
import Filters from '../modules/Product/Components/Filters/Filters.vue';
import Modal from '../modules/Product/Components/Modal/Modal.vue';
import Table from '../modules/Product/Components/Table/Table.vue';
import { api } from '../utils/api';

// Data

const filterBarCode = ref<string>('')
const currentPage = ref<number>(0);
const totalProducts = ref<number>(0);
const filterProductName = ref<string>('')
const modalVisible = ref<boolean>(false);
const image = ref(null);

const selectedProduct = ref<Product>({
    barCode: "",
    id: 0,
    imageUrl: "",
    price: 0,
    name: "",
})

const data = ref<Product[]>([])

const hasNextPage = computed(() => {
  const value = totalProducts.value - ((currentPage.value + 1) * 10);
  console.log(value)
  return value > 0;
})

// EndData

// Functions

const onSubmitForm = async () => {
  try {
    if (!selectedProduct.value.id) {
      console.log(image.value)
      await api.post('product', selectedProduct.value);
    } else {
      await api.put(`product/${selectedProduct.value.id}`, selectedProduct.value);
    }
    resetProductForm()

    fetchData();

    modalVisible.value = false;

  } catch (err) {
    console.error(err);
  }
}

const fetchData = async () => {
  var url = "product";

  if (filterBarCode.value) url += `?barCode=${filterBarCode.value}`;

  if (filterProductName.value) {
    if (url.includes('?')) {
      url += `&name=${filterProductName.value}`
    } else {
      url += `?name=${filterProductName.value}`
    }
  };

  if (url.includes('?')) {
    url += `&page=${currentPage.value}` 
  } else {
    url += `?page=${currentPage.value}` 
  }

  const response = await api.get<PaginatedProduct>(url);

  if (response.status == 200) {
    data.value = response.data.products;
    currentPage.value = response.data.pageIndex;
    totalProducts.value = response.data.total;
  }
}

const editProduct = (editP: Product) => {
  selectedProduct.value = {
    barCode: editP.barCode,
    id: editP.id,
    imageUrl: editP.imageUrl,
    price: editP.price,
    name: editP.name
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
  }
}

const clearFilters = () => {
  filterBarCode.value = '';
  filterProductName.value = '';
  fetchData();
}

// EndFunctions

onMounted(() => {
  fetchData();
})

</script>

<template>
    <main class="bg-slate-100 w-full min-h-[h-screen] flex items-center justify-center">
    <div class="w-3/4 flex flex-col items-center justify-center my-20">
      <h1 class="text-slate-700 text-4xl font-bold ">Listagem de produtos</h1>
      <div class="w-full flex justify-between items-center">
        <div class="flex gap-2 my-4 text-white">
          <Filters v-model:bar="filterBarCode" v-model:product="filterProductName" />
          <Button icon="pi pi-search" aria-label="Pesquisar"  type="button" @click="() => fetchData()" />
          <Button icon="pi pi-eraser" aria-label="Limpar filtros"  type="button" @click="clearFilters"/>
        </div>
        <Button label="Novo" @click="modalVisible = true" />
      </div>
      <Table :data="data" @edit-product="editProduct" />
      <div class="w-full flex justify-between items-end">
        <p class="text-sm text-slate-600">Mostrando {{ data.length }} de {{ totalProducts }} registros</p>
        <div class="flex justify-end gap-1 my-2">
          <Button :disabled="currentPage == 0" icon="pi pi-arrow-left" label="Página anterior" @click="() => {
            if (currentPage != 0) {
              currentPage -= 1;
            }
            fetchData()
          }" />
          <Button :disabled="!hasNextPage" icon="pi pi-arrow-right" label="Próxima página" icon-pos="right" @click="() => {
            currentPage += 1
            fetchData()
          }" />
        </div>
      </div>
    </div>
    <Modal v-model:visible="modalVisible" v-model="selectedProduct" @submit-product-form="onSubmitForm" />
  </main>
</template>