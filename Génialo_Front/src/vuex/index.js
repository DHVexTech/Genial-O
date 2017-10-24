import Vue from 'vue'
import Vuex from 'vuex'
Vue.use(Vuex)

import motor from './modules/motor'
import manual from './modules/manual'
import auto from './modules/auto'

const debug = process.env.NODE_ENV !== 'production'

export const store = new Vuex.Store({
  modules: {
    Motor: motor,
    Manual: manual,
    Auto: auto

  }
});

console.log('STORE AUTO : '+ store.auto);
console.log('STORE MANUAL : '+ store.manual);
