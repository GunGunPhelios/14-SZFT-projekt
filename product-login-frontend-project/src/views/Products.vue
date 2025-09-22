<script setup>
import { ref, onMounted } from "vue";
import api from "../api";
import { useAuthStore } from "../store/auth";
import { useRouter } from "vue-router";

const products = ref([]);
const errorMessage = ref("");
const auth = useAuthStore();
const router = useRouter();

const loadProducts = async () => {
  try {
    const response = await api.get("/product");
    products.value = response.data;
  } catch (err) {
    errorMessage.value = "Nem sikerült betölteni a termékeket.";
  }
};

const deleteProduct = async (id) => {
  if (!auth.isLoggedIn) return;
  if (!confirm("Biztosan törölni szeretnéd a terméket?")) return;

  try {
    await api.delete(`/product/${id}`);
    products.value = products.value.filter((p) => p.id !== id);
  } catch (err) {
    alert("Hiba történt a törlés során!");
  }
};

const goToCreate = () => {
  router.push("/products/create");
};

const goToEdit = (id) => {
  router.push(`/products/edit/${id}`);
};

onMounted(loadProducts);
</script>

<template>
  <div>
    <h2>Termékek</h2>
    <p v-if="errorMessage" style="color:red">{{ errorMessage }}</p>

    <!-- Hozzáadás gomb, csak bejelentkezett felhasználóknak -->
    <button v-if="auth.isLoggedIn" @click="goToCreate">Új termék hozzáadása</button>

    <table border="1" cellpadding="5" cellspacing="0">
      <thead>
        <tr>
          <th>Id</th>
          <th>Név</th>
          <th>Leírás</th>
          <th>Ár</th>
          <th>Készlet</th>
          <th>Kategória</th>
          <th>Létrehozva</th>
          <th v-if="auth.isLoggedIn">Műveletek</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="product in products" :key="product.id">
          <td>{{ product.id }}</td>
          <td>{{ product.name }}</td>
          <td>{{ product.description }}</td>
          <td>{{ product.price }}</td>
          <td>{{ product.stockQuantity }}</td>
          <td>{{ product.category }}</td>
          <td>{{ new Date(product.createdAt).toLocaleString() }}</td>
          <td v-if="auth.isLoggedIn">
            <button @click="goToEdit(product.id)">Szerkesztés</button>
            <button @click="deleteProduct(product.id)">Törlés</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>
