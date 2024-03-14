<script setup lang="ts">
import Button from 'primevue/button';
import Column from 'primevue/column';
import DataTable from 'primevue/datatable';
import { Product } from '../../../../types/Product';

const props = defineProps<{
    data: Product[]
}>()

</script>


<template>
    <DataTable :value="props.data" style="min-width: 100%">
        <Column field="id" header="Id" style="width: 25%"></Column>
        <Column field="barCode" header="Código de barras" style="width: 25%"></Column>
        <Column field="name" header="Nome" style="width: 25%"></Column>
        <Column field="price" header="Preço" style="width: 25%" :sortable="true"></Column>
        <Column field="id">
          <template #body="slotProps">
            <Button label="Edit" icon="pi pi-pencil" />
          </template>
        </Column>
      </DataTable>
</template>