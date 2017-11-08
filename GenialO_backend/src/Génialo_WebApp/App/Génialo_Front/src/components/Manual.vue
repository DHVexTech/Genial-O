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
                <div v-if="ConnectToCamera">
                    <b-container class="conteneur">
                        <iframe style="background-color:black;">test</iframe>
                    </b-container>
                </div>

                <div v-if="Motor">
                    <b-row>
                        <b-col><img src="../assets/up-arrow.svg" v-bind:class="{ ClassKeyDown: up }" v-on:click="changeDirection('directionUp')" id="ArrowUp" width="100"></b-col>
                    </b-row>
                    <b-row>
                        <b-col>
                            <img src="../assets/left-arrow.svg" v-bind:class="{ ClassKeyDown: left }" v-on:click="changeDirection('directionLeft')"  style="margin-bottom:200px;"  width="100">
                            <img src="../assets/down-arrow.svg" v-bind:class="{ ClassKeyDown: down }" v-on:click="changeDirection('directionDown')" width="100">
                            <img src="../assets/right-arrow.svg" v-bind:class="{ ClassKeyDown: right }" v-on:click="changeDirection('directionRight')" style="margin-bottom:200px;" width="100">
                        </b-col>
                    </b-row>
                </div>

                
                <br>
            </b-jumbotron>
        </b-row>
    </b-container>
</template>

<script>
import { mapGetters, mapMutations, mapActions} from 'vuex'
import $ from 'jquery' 

const DirectionUp = 'directionUp';
const DirectionDown = 'directionDown';
const DirectionLeft = 'directionLeft';
const DirectionRight = 'directionRight';

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
      
  },
  beforeDestroy(){
      
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
    ManageKey: function(event){
        switch (event.which){
            case 90: return this.changeDirection(DirectionUp);
            case 83:  return this.changeDirection(DirectionDown);
            case 81: return this.changeDirection(DirectionLeft);
            case 68: return this.changeDirection(DirectionRight);
        }
    },
    changeDirection: function(direction){
        if(this.lastKeyTime+this.TimeAllowBetweenKeyDown < new Date().getTime() )
        this.lastKeyTime = new Date().getTime();
        switch (direction) {
            case DirectionUp:
                this.up = !this.up;
                if(this.down) this.down = !this.down;
                break;
            case DirectionDown:
                this.down = !this.down;
                if(this.up) this.up = !this.up;
                break;
            case DirectionLeft:
                this.left = !this.left;
                if(this.right) this.right = !this.right;
                break;
            case DirectionRight:
                this.right = !this.right;
                if(this.left) this.left = !this.left;
                break;
            default:
                break;
        }
        if(this.left || this.right || this.up || this.down) { // Bloquer le défilement
            return false;
        }
    },
    Launch: function(string){
        switch (string) {
            case 'camera':
                this.SetConnectToCamera();
                break;
            case 'motor':
                this.SetMotor();
                if(this.Motor) window.addEventListener("keyup",this.ManageKey);
                else window.removeEventListener("keyup",this.ManageKey);
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
