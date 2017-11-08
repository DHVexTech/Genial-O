<template>
  <b-navbar toggleable="md" type="light" style="background-color:#E9ECEF;margin-bottom:50px;-webkit-box-shadow: 0px 2px 5px 0px rgba(0,0,0,0.75);-moz-box-shadow: 0px 2px 5px 0px rgba(0,0,0,0.75);box-shadow: 0px 2px 5px 0px rgba(0,0,0,0.75);">
    <b-nav-toggle target="nav_collapse"></b-nav-toggle>
      <b-collapse is-nav id="nav_collapse">
        <b-navbar-nav>
          <b-nav-item @click="BackToTheFirstMenu()">Génial-O</b-nav-item>
          <b-nav-item @click="showModal">{{this.UpdateText}}</b-nav-item>
        </b-navbar-nav>
    </b-collapse>
      <div>
        <b-modal ref="myModalRef" hide-footer title="Êtes-vous vraiment sur ?">
          <div class="d-block text-center">
              <h3>Voulez-vous vraiment vous déconnecter du robot ?</h3>
          </div>
          <b-btn class="mt-3" variant="outline-danger" @click="hideModal(false)">Annuler</b-btn>
          <b-btn class="mt-3" variant="outline-success" @click="hideModal(true)">Se déconnecter</b-btn>
        </b-modal>
      </div>
  </b-navbar>
</template>

<script>
import { mapGetters, mapMutations, mapActions} from 'vuex'
export default {
  name: 'Nav',
  data () {
    return {
    }
  }, 
  watch:{

  },
  created(){
  },
  computed: {
    ...mapGetters([
      'ConnectToRobot',
      'Auto',
      'Manual'
    ]),
    UpdateText: function() {
      if(this.ConnectToRobot) return "Se déconnecter du robot"; else return "Se connecter au robot";
    }
  },
  methods:{
    ...mapActions([
      'SetConnectToRobot',
      'SetBoolAuto',
      'SetBoolManual',
      'SetTest'
    ]),
    BackToTheFirstMenu(){
      this.SetConnectToRobot();
      this.SetConnectToRobot();
  },
    Boot() {
      this.SetConnectToRobot();
    },
    showModal() {
      if(this.ConnectToRobot)
        this.$refs.myModalRef.show();
      else 
        this.Boot();
    },
    hideModal(bool) {
      this.$refs.myModalRef.hide();
      if(bool) this.Boot();
    },
  }
}
</script>