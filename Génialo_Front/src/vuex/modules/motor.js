import * as types from '../mutation-types'

export default {
  state: {
    motor: false,
  },
  actions:{
      SetMotor (context) {
        context.commit(types.SET_MOTOR);
      }
  },
  mutations: {
    [types.SET_MOTOR] (state){
        state.motor = !state.motor;
    }
  },
  getters: {
    Motor: (state) => {
        return state.motor;
    }
  }
};

