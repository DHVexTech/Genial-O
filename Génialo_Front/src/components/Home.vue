<template>
  <b-container style="height:100%;" v-if="this.Manual() == true && this.Auto() == false">
Manual

  </b-container>
  <b-container style="height:100%;" v-else-if="this.Manual() == false && this.Auto() == true">

auto
  </b-container>
  <b-container style="height:100%;" v-else>
    <MenuToSelect></MenuToSelect>
  </b-container>


</template>

<script>
import { mapGetters, mapMutations} from 'vuex'
import SelectMenu from './SelectMenu.vue'
export default {
  name: 'Home',
  data () {
    return {
    }
  },
  methods:{
    ...mapGetters([
      'Count',
      'Manual',
      'Auto'
    ]),
    ...mapMutations([
      'Increment',
      'SetBoolAuto',
      'SetBoolManual'

    ]),
  },
  components: {
    'MenuToSelect': SelectMenu
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
