<script setup>
import { ref } from "vue";
import { useRouter } from "vue-router";
import api from "../api";

const name = ref("");
const description = ref("");
const price = ref(0);
const stockQuantity = ref(0);
const category = ref("");

const router = useRouter();

const createProduct = async () => {
  try {
    await api.post("/product", {
      name: name.value,
      description: description.value,
      price: price.value,
      stockQuantity: stockQuantity.value,
      category: category.value,
    });
    router.push("/products");
  } catch (err) {
    alert("Hiba történt a termék létrehozásakor!");
  }
};
</script>

<template>
  <div>
    <h2>Új termék létrehozása</h2>
    <form @submit.prevent="createProduct">
      <div><label>Név:</label><input v-model="name" required /></div>
      <div><label>Leírás:</label><input v-model="description" /></div>
      <div><label>Ár:</label><input v-model.number="price" type="number" required /></div>
      <div><label>Készlet:</label><input v-model.number="stockQuantity" type="number" required /></div>
      <div><label>Kategória:</label><input v-model="category" /></div>
      <button type="submit">Mentés</button>
    </form>
  </div>
</template>
