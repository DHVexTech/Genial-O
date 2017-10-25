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
                <b-container class="conteneur">
                    <iframe style="background-color:black;">test</iframe>
                </b-container>
                <b-row>
                    <b-col><img src="../assets/up-arrow.svg" v-bind:class="{ ClassKeyDown: up }" id="ArrowUp" width="100" alt="Un kiwi en SVG"></b-col>
                </b-row>
                <b-row>
                    <b-col>
                        <img src="../assets/left-arrow.svg" v-bind:class="{ ClassKeyDown: left }"  style="margin-bottom:200px;"  width="100" alt="Un kiwi en SVG">
                        <img src="../assets/down-arrow.svg" v-bind:class="{ ClassKeyDown: down }" width="100" alt="Un kiwi en SVG">
                        <img src="../assets/right-arrow.svg" v-bind:class="{ ClassKeyDown: right }" style="margin-bottom:200px;" width="100" alt="Un kiwi en SVG">
                    </b-col>
                </b-row>
                
                <br>
            </b-jumbotron>
        </b-row>
    </b-container>
</template>

<script>
import { mapGetters, mapMutations, mapActions} from 'vuex'
//import $ from 'jquery' 

export default {
  name: 'Auto',
  data () {
    return {
        up: false,
        left: false,
        right: false,
        down: false,
        lastKeyTime: new Date().getTime(),
        TimeAllowBetweenKeyDown: 1
    }
  },
  created() {
      window.addEventListener("keydown",this.changecss);
  },
  beforeDestroy(){
      window.removeEventListener("keydown",this.changecss);
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
    changecss: function(event){
        if(this.lastKeyTime+this.TimeAllowBetweenKeyDown < new Date().getTime() )
        this.lastKeyTime = new Date().getTime();
        if (event.which == '38') this.up = !this.up;
        else if (event.which == '40') this.down = !this.down;
        else if (event.which == '37') this.left = !this.left;
        else if (event.which == '39') this.right = !this.right
    },
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
.ClassKeyDown{
    background-color: grey;
}

a {
  color: #42b983;
}

</style>
