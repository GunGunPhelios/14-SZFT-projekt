import { createRouter, createWebHistory } from "vue-router";
import Login from "../views/Login.vue";
import Products from "../views/Products.vue";
import ProductCreate from "../views/ProductCreate.vue";
import ProductEdit from "../views/ProductEdit.vue";

const routes = [
  { path: "/", redirect: "/products" },
  { path: "/login", component: Login },
  { path: "/products", component: Products },
  { path: "/products/create", component: ProductCreate, meta: { requiresAuth: true } },
  { path: "/products/edit/:id", component: ProductEdit, meta: { requiresAuth: true } },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
