<script setup lang="ts">
import { defineModel, defineEmits } from 'vue';
import Button from 'primevue/button';
import InputText from 'primevue/inputtext';
import InputNumber from 'primevue/inputnumber';
import Dialog from 'primevue/dialog';
import { Product } from '../../../../types/Product';

const visible = defineModel<boolean>('visible');
// const product = defineModel<Product>('product')

const prod = defineModel<Product>({
    required: false,
    default: {
        imageUrl: "",
        name: "",
        price: 0,
        barCode: ""
    }
});

const emit = defineEmits<{
    (e: 'submit-product-form'): void
}>()

// const props = withDefaults(defineProps<{
//     name: string
//     price: number
//     barCode: string
//     id?: number
// }>(), {
//     name: "",
//     price: 0,
//     barCode: "",
//     id: 0
// })


</script>

<template>
    <Dialog v-model:visible="visible" modal header="Produto: " :style="{ width: '600px' }">
        <div class="flex flex-col gap-4">
            <div class="flex flex-col gap-2">
                <label for="name">Nome</label>
                <InputText id="name" v-model="prod.name" />
            </div>
            <div class="flex flex-col gap-2">
                <label for="price">Preço</label>
                <InputNumber id="price" v-model="prod.price" />
            </div>
            <div class="flex flex-col gap-2">
                <label for="barCode">Código de barras</label>
                <InputText id="barCode" v-model="prod.barCode"  />
            </div>
        </div>
        <div class="flex w-full gap-2 justify-end my-4">
            <Button label="Cancelar" @click="visible = false" severity="danger" class="text-white" />
            <Button label="Salvar" @click="() => emit('submit-product-form')" />
        </div>
    </Dialog>
</template>