<script setup>
import { useAuthStore } from "./store/auth";
import { useRouter } from "vue-router";

const auth = useAuthStore();
const router = useRouter();

const logout = () => {
  auth.logout();
  router.push("/login");
};
</script>

<template>
  <header>
    <h1>Product Login Frontend</h1>
    <nav>
      <router-link to="/products">Termékek</router-link> |
      <router-link to="/login">Bejelentkezés</router-link> |
      <button v-if="auth.isLoggedIn" @click="logout">Kijelentkezés</button>
    </nav>
  </header>

  <main>
    <router-view />
  </main>
</template>
