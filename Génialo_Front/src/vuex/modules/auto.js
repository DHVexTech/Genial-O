import * as types from '../mutation-types'

export default {
  state: {
    auto: false,
  },
  actions:{
    SetBoolAuto (context) {
      if(context.rootGetters.ConnectToCamera) context.dispatch('SetConnectToCamera');
      if(context.rootGetters.Motor) context.dispatch('SetMotor');
      context.commit(types.SET_BOOL_AUTO);
    }
  },
  mutations: {
    [types.SET_BOOL_AUTO] (state){
        state.auto = !state.auto;

      }
  },
  getters: {
    Auto: (state) => {
        return state.auto;
    }
  }
};

