import * as types from '../mutation-types'

export default {
  state: {
    connectToCamera: false,
  },
  actions:{
      SetConnectToCamera (context) {
        context.commit(types.SET_CONNECT_TO_CAMERA);
      }
  },
  mutations: {
    [types.SET_CONNECT_TO_CAMERA] (state){
        state.connectToCamera = !state.connectToCamera;
    }
  },
  getters: {
    ConnectToCamera: (state) => {
        return state.connectToCamera;
    }
  }
};

