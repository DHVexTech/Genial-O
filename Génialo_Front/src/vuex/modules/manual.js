import * as types from '../mutation-types'

export default {
  state: {
    manual: false,
  },
  actions:{
    SetBoolManual (context) {
        context.commit(types.SET_BOOL_MANUAL);
    }
  },
  mutations: {
    [types.SET_BOOL_MANUAL] (state){
        state.manual = !state.manual;

      }
  },
  getters: {
    Manual: (state) => {
        return state.manual;
    }
  }
};

