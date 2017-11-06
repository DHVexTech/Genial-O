import Vue from 'vue'
import Vuex from 'vuex'
Vue.use(Vuex)
import connectToCamera from './modules/connectToCamera'
import manual from './modules/manual'
import auto from './modules/auto'
import camera from './modules/camera'
import motor from './modules/motor'
const debug = process.env.NODE_ENV !== 'production'

export const store = new Vuex.Store({
  modules: {
    ConnectToCamera: connectToCamera,
    Manual: manual,
    Auto: auto,
    Camera: camera,
    Motor: motor
  }
});