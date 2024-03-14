<script setup lang="ts">
import Button from 'primevue/button';
import Column from 'primevue/column';
import DataTable from 'primevue/datatable';
import { Product } from '../../../../types/Product';

const props = defineProps<{
    data: Product[]
}>()

const emit = defineEmits<{
  (e: 'edit-product', prod: Product): void
}>();

</script>


<template>
    <DataTable :value="props.data" style="min-width: 100%">
        <Column field="id" header="Id" style="width: 8%"></Column>
        <Column field="barCode" header="Código de barras" style="width: 25%"></Column>
        <Column field="name" header="Nome" style="width: 45%"></Column>
        <Column field="price" header="Preço" style="width: 20%" :sortable="true"></Column>
        <Column field="id">
          <template #body="slotProps">
            <Button label="Edit" icon="pi pi-pencil" @click="() => emit('edit-product', slotProps.data)" />
          </template>
        </Column>
      </DataTable>
</template>