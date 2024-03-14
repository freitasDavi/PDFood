import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import PrimeVue from "primevue/config"
import Lara from './presets/lara';
import { router } from './router';

const app = createApp(App);

app.use(PrimeVue, {
    unstyled: true,
    pt: Lara
})

app.use(router)

app.mount('#app')
