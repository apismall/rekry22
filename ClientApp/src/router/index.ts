import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import Home from "@/views/Home.vue";
import About from "@/views/About.vue"
import Invoice from "@/views/Invoice.vue"

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/about",
    name: "About",
    component: About,
  },
  {
    path: "/invoice/:id",
    name: "Invoice",
    component: Invoice,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;