<script setup>
import { ref, onMounted } from "vue";
import { useRoute, useRouter } from "vue-router";
import api from "../api";

const route = useRoute();
const router = useRouter();
const id = route.params.id;

const name = ref("");
const description = ref("");
const price = ref(0);
const stockQuantity = ref(0);
const category = ref("");

const loadProduct = async () => {
  try {
    const res = await api.get(`/product/${id}`);
    const p = res.data;
    name.value = p.name;
    description.value = p.description;
    price.value = p.price;
    stockQuantity.value = p.stockQuantity;
    category.value = p.category;
  } catch {
    alert("Hiba a termék betöltésekor!");
    router.push("/products");
  }
};

const updateProduct = async () => {
  try {
    await api.put(`/product/${id}`, {
      name: name.value,
      description: description.value,
      price: price.value,
      stockQuantity: stockQuantity.value,
      category: category.value,
    });
    router.push("/products");
  } catch {
    alert("Hiba a termék frissítésekor!");
  }
};

onMounted(loadProduct);
</script>

<template>
  <div>
    <h2>Termék szerkesztése</h2>
    <form @submit.prevent="updateProduct">
      <div><label>Név:</label><input v-model="name" required /></div>
      <div><label>Leírás:</label><input v-model="description" /></div>
      <div><label>Ár:</label><input v-model.number="price" type="number" required /></div>
      <div><label>Készlet:</label><input v-model.number="stockQuantity" type="number" required /></div>
      <div><label>Kategória:</label><input v-model="category" /></div>
      <button type="submit">Mentés</button>
    </form>
  </div>
</template>
