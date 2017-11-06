import * as types from '../mutation-types'

export default {
  state: {
    connectToRobot: false,
  },
  actions:{
      SetConnectToRobot (context) {
          this.commit('SET_CONNECT_TO_ROBOT');
          if(!context.state.connectToRobot) {
            if(context.rootGetters.Manual) context.dispatch('SetBoolManual');
            if(context.rootGetters.Auto) context.dispatch('SetBoolAuto');
          }
      }
  },
  mutations: {
    [types.SET_CONNECT_TO_ROBOT] (state){
        state.connectToRobot = !state.connectToRobot;

      }
  },
  getters: {
    ConnectToRobot: (state) => {
        return state.connectToRobot;
    }
  }
};

