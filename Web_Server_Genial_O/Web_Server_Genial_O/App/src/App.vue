<template>
  <div id="app">
    <navTop></navTop>
    <router-view style="height:auto;" />
    <FooterBottom></FooterBottom>
  </div>
</template>

<script>
import Nav from './components/Nav.vue'
import Footer from './components/Footer.vue'
export default {
  name: 'app',
  components: {
    'navTop': Nav,
    'FooterBottom': Footer
  }
  
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  vertical-align: middle;
  color: #2c3e50;
  height:100%;
  width:100%;
}
html, body {
  height:100%;
  width:100%;
}
body {
  background-image:url("./assets/fond_website.png");
  background-repeat:repeat-y;
  background-size: cover;
}

</style>
