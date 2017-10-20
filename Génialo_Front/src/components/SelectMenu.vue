<template>
    <div>
      <b-row>
        <b-container>
            <b-jumbotron header="toto">
              <h5>
                  Lorem, ipsum dolor sit amet consectetur adipisicing elit. Ducimus, ex, perspiciatis esse officiis ratione sint iste alias nesciunt similique, in illo exercitationem corporis. Quam earum, at dignissimos omnis consequuntur odit! Explicabo nemo, labore voluptatibus cupiditate odio aut asperiores natus aliquam? Quos dolorem quaerat debitis soluta in pariatur delectus eius veritatis animi quis. Asperiores soluta quae veritatis, temporibus placeat fuga sed!Saepe laborum at sapiente enim, reprehenderit facilis ullam, quod commodi sequi esse tenetur. Possimus animi magni voluptas tempora nihil optio adipisci eius consectetur ipsum illum minus, aliquam totam repellat repellendus?Quo illo quia sunt in fugit aspernatur eos voluptatum. Blanditiis vero tempora exercitationem iure sequi rerum aperiam numquam laudantium, velit eligendi odit aspernatur voluptates alias debitis ipsam tempore perferendis porro.Placeat dolorem impedit sed iusto magni tempore excepturi voluptatem maiores id repellendus officia qui animi eaque nihil eveniet dolor quos, eius mollitia quam ad officiis? Aut minima vero ex nesciunt!
              </h5>
            </b-jumbotron>
        </b-container>
      </b-row>
      <b-row>
        <b-col>
            <b-jumbotron header="Manuel" lead="Prenez le contrôle du robot!" >
              <p></p>
              <b-btn v-if="this.GetConnectToRobot()" v-b-tooltip.hover.left="'Controlez le robot!'" variant="outline-success" v-on:click="Appear('boolManual')">Confirmer</b-btn>
              <b-btn v-if="!this.GetConnectToRobot()" variant="outline-danger" disabled>Vous devez vous connecter au robot!</b-btn>
            </b-jumbotron>
        </b-col>
        <b-col>
            <b-jumbotron header="Automatique" lead="Parametrer le mode automatique" >
              <p></p>
              <b-btn v-if="this.GetConnectToRobot()" v-b-tooltip.hover.left="'Parametrez notre robot!'" variant="outline-success" v-on:click="Appear('boolAuto')">Confirmer</b-btn>
              <b-btn v-if="!this.GetConnectToRobot()" variant="outline-danger" disabled>Vous devez vous connecter au robot!</b-btn>
            </b-jumbotron>
        </b-col>
      </b-row>
    </div>
</template>
<script>
import { mapGetters, mapMutations} from 'vuex'
export default {
  name: 'SelectMenu',
  data () {
    return {
    }
  },
  methods:{
    ...mapGetters([
      'Count',
      'Manual',
      'Auto',
      'GetConnectToRobot'
    ]),
    ...mapMutations([
      'Increment',
      'SetBoolAuto',
      'SetBoolManual'

    ]),
    Appear: function(field) {
      switch (field) {
        case 'boolAuto':
          this.SetBoolAuto();
          break;
        case 'boolManual':
          this.SetBoolManual();
          break;
        default:
          break;
      }
      console.log('AUTO :'+this.Auto());
      console.log('Manual :'+this.Manual());
    }

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
