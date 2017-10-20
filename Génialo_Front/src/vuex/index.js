import Vue from 'vue'
import Vuex from 'vuex'
import * as actions from './actions'
//import mutations from './mutations'
//import * as getters from './getters'
import { Increment, SetBoolAuto, SetBoolManual } from './mutation-types'

Vue.use(Vuex)

const debug = process.env.NODE_ENV !== 'production'




export const store = new Vuex.Store({
  state: {
    manual: false,
    auto: false,
    count: 0
  },
  getters: {
    Count: state => {
      return state.count;
    },
    Manual: state => {
      return state.manual;
    },
    Auto: state => {
      return state.auto;
    }
  },
  mutations: {
    Increment (state) {
      state.count++
    },
    SetBoolAuto(state){
      state.auto = !state.auto;
    },
    SetBoolManual(state){
      state.manual = !state.manual;
    }
  }
});

console.log('STORE AUTO : '+ store.auto);
console.log('STORE MANUAL : '+ store.manual);

//console.log(store.getters.num());