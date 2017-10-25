<template>
    <b-container style="height:100%;">
        <b-row>
            <b-jumbotron header="Lancer les moteurs ou se connecter à la caméra">
                <div>
                    <b-btn class="mt-3" variant="outline-danger" v-if="Motor" @click="Launch('motor')">Eteindre les moteurs</b-btn>
                    <b-btn class="mt-3" variant="outline-success" v-if="!Motor" @click="Launch('motor')">Lancer les moteurs</b-btn>
                    <b-btn class="mt-3" variant="outline-danger" v-if="this.ConnectToCamera" @click="Launch('camera')">Eteindre la caméra</b-btn>
                    <b-btn class="mt-3" variant="outline-success" v-if="!this.ConnectToCamera" @click="Launch('camera')">Lancer la caméra</b-btn>
                </div>
                <br>
                <h5>
                    Lorem, ipsum dolor sit amet consectetur adipisicing elit. Ducimus, ex, perspiciatis esse officiis ratione sint iste alias nesciunt similique, in illo exercitationem corporis. Quam earum, at dignissimos omnis consequuntur odit! Explicabo nemo, labore voluptatibus cupiditate odio aut asperiores natus aliquam? Quos dolorem quaerat debitis soluta in pariatur delectus eius veritatis animi quis. Asperiores soluta quae veritatis, temporibus placeat fuga sed!Saepe laborum at sapiente enim, reprehenderit facilis ullam, quod commodi sequi esse tenetur. Possimus animi magni voluptas tempora nihil optio adipisci eius consectetur ipsum illum minus, aliquam totam repellat repellendus?Quo illo quia sunt in fugit aspernatur eos voluptatum. Blanditiis vero tempora exercitationem iure sequi rerum aperiam numquam laudantium, velit eligendi odit aspernatur voluptates alias debitis ipsam tempore perferendis porro.Placeat dolorem impedit sed iusto magni tempore excepturi voluptatem maiores id repellendus officia qui animi eaque nihil eveniet dolor quos, eius mollitia quam ad officiis? Aut minima vero ex nesciunt!
                </h5>
                
            </b-jumbotron>
            <b-col>
                <b-jumbotron header="Cartographie">
                    <h5>
                        Lorem, ipsum dolor sit amet consectetur adipisicing elit. Ducimus, ex, perspiciatis esse officiis ratione sint iste alias nesciunt similique, in illo exercitationem corporis. Quam earum, at dignissimos omnis consequuntur odit! Explicabo nemo, labore voluptatibus cupiditate odio aut asperiores natus aliquam? Quos dolorem quaerat debitis soluta in pariatur delectus eius veritatis animi quis. Asperiores soluta quae veritatis, temporibus placeat fuga sed!Saepe laborum at sapiente enim, reprehenderit facilis ullam, quod commodi sequi esse tenetur. Possimus animi magni voluptas tempora nihil optio adipisci eius consectetur ipsum illum minus, aliquam totam repellat repellendus?Quo illo quia sunt in fugit aspernatur eos voluptatum. Blanditiis vero tempora exercitationem iure sequi rerum aperiam numquam laudantium, velit eligendi odit aspernatur voluptates alias debitis ipsam tempore perferendis porro.Placeat dolorem impedit sed iusto magni tempore excepturi voluptatem maiores id repellendus officia qui animi eaque nihil eveniet dolor quos, eius mollitia quam ad officiis? Aut minima vero ex nesciunt!
                    </h5>
                </b-jumbotron>
            </b-col>
            <b-col>
                <b-jumbotron header="Cartographie">
                    <h5>
                        Lorem, ipsum dolor sit amet consectetur adipisicing elit. Ducimus, ex, perspiciatis esse officiis ratione sint iste alias nesciunt similique, in illo exercitationem corporis. Quam earum, at dignissimos omnis consequuntur odit! Explicabo nemo, labore voluptatibus cupiditate odio aut asperiores natus aliquam? Quos dolorem quaerat debitis soluta in pariatur delectus eius veritatis animi quis. Asperiores soluta quae veritatis, temporibus placeat fuga sed!Saepe laborum at sapiente enim, reprehenderit facilis ullam, quod commodi sequi esse tenetur. Possimus animi magni voluptas tempora nihil optio adipisci eius consectetur ipsum illum minus, aliquam totam repellat repellendus?Quo illo quia sunt in fugit aspernatur eos voluptatum. Blanditiis vero tempora exercitationem iure sequi rerum aperiam numquam laudantium, velit eligendi odit aspernatur voluptates alias debitis ipsam tempore perferendis porro.Placeat dolorem impedit sed iusto magni tempore excepturi voluptatem maiores id repellendus officia qui animi eaque nihil eveniet dolor quos, eius mollitia quam ad officiis? Aut minima vero ex nesciunt!
                    </h5>
                </b-jumbotron>
            </b-col>
        </b-row>
    </b-container>
</template>

<script>
import { mapGetters, mapMutations, mapActions} from 'vuex'
export default {
  name: 'Auto',
  data () {
    return {
        launchCartography : false
    }
  },
  computed: {
    ...mapGetters([
      'ConnectToCamera',
      'Motor'
    ]),
  },
  methods:{
    ...mapActions([
      'SetConnectToCamera',
      'SetMotor'
    ]),
    Launch: function(string){
        switch (string) {
            case 'camera':
            this.SetConnectToCamera();
                break;
            case 'motor':
            this.SetMotor();
                break;
            default:
                break;
        }
    }
  },
  components: {
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
