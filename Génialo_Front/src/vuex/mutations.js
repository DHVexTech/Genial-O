  export const Increment =(state)=> {
    state.count++;
  }
  export const SetBoolAuto=(state)=>{
    state.auto = !state.auto;
    if(state.manual) state.manual = !state.manual;
  }
  export const SetBoolManual=(state)=>{
    state.manual = !state.manual;
    if(state.auto) state.auto = !state.auto;
  }
  export const SetConnectToRobot=(state) =>{
    state.ConnectToRobot = !state.ConnectToRobot;
    if(!state.ConnectToRobot) {
      if(state.manual) state.manual = !state.manual;
      if(state.auto) state.auto = !state.auto;
    }
  }