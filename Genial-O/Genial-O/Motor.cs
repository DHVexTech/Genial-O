using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Genial_O
{
    class Motor
    {
        readonly PWM _motor;
        readonly OutputPort _frontDirection;

        public Motor(Cpu.PWMChannel motor, Cpu.Pin motorFrontDirection)
        {
            _motor = new PWM(motor, 500, 0.8, false);
            _frontDirection = new OutputPort(motorFrontDirection, true);
            _frontDirection.Write(true);
        }


    } 
}
