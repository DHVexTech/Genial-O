<template>
  <b-container style="height:100%;" v-if="this.Manual == true">
    <manual></manual>
  </b-container>
  <b-container style="height:100%;" v-else-if="this.Auto == true">
    <auto></auto>
  </b-container>
  <b-container style="height:100%;" v-else>
    <MenuToSelect></MenuToSelect>
  </b-container>


</template>

<script>
import { mapGetters, mapMutations, mapActions} from 'vuex'
import SelectMenu from './SelectMenu.vue'
import Auto from './Auto.vue'
import Manual from './Manual.vue'
export default {
  name: 'Home',
  data () {
    return {
    }
  },
  computed: {
    ...mapGetters([
      'Manual',
      'Auto'
    ]),
  },
  components: {
    'MenuToSelect': SelectMenu,
    'auto': Auto,
    'manual': Manual
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.display-3{
  font-size: 2.5rem;
}
h1, h2 {
  font-weight: normal;
}


a {
  color: #42b983;
}
</style>
