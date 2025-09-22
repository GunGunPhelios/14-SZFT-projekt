<script setup>
import { ref } from "vue";
import { useRouter } from "vue-router";
import { useAuthStore } from "../store/auth";
import api from "../api";

const email = ref("");
const password = ref("");
const errorMessage = ref("");
const router = useRouter();
const auth = useAuthStore();

const login = async () => {
  try {
    const response = await api.post("/auth/login", {
      email: email.value,
      password: password.value,
    });

    auth.login(response.data.accessToken, response.data.refreshToken);
    router.push("/products");
  } catch (err) {
    errorMessage.value = err.response?.data?.message || "Hiba történt a bejelentkezéskor.";
  }
};
</script>

<template>
  <div>
    <h2>Bejelentkezés</h2>
    <form @submit.prevent="login">
      <div>
        <label>Email vagy felhasználónév:</label>
        <input v-model="email" type="text" required />
      </div>
      <div>
        <label>Jelszó:</label>
        <input v-model="password" type="password" required />
      </div>
      <button type="submit">Belépés</button>
    </form>
    <p v-if="errorMessage" style="color:red">{{ errorMessage }}</p>
  </div>
</template>
