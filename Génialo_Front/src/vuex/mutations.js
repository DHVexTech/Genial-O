 /*   mutations: {
      increment (state) {
        state.count++
      }
    }*/

  
//export const mutations = {
  export const Increment =(state)=> {
    state.count++;
  }
  export const SetBoolAuto=(state)=>{
    state.auto = !state.auto;
  }
  export const SetBoolManual=(state)=>{
    state.manual = !state.manual;
  }
  export const SetConnectToRobot=(state) =>{
    state.ConnectToRobot = !state.ConnectToRobot;
  }
//}