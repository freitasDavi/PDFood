import { createRouter, createWebHashHistory } from "vue-router"
import HomePage from "../pages/index.vue"

const routes = [
    { path: '/', component: HomePage }
]

const router = createRouter({
    history: createWebHashHistory(),
    routes
})

export { router }