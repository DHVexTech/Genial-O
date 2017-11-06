using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Genial_O
{
    public class Motor
    {
        readonly PWM _motor;
        readonly OutputPort _frontDirection;
        Direction _motorDirection;

        public Motor(Cpu.PWMChannel motor, Cpu.Pin motorFrontDirection)
        {
            _motor = new PWM(motor, 500, 0.8, false);
            _frontDirection = new OutputPort(motorFrontDirection, true);
            _motor.DutyCycle = 0.4;
        }

        public PWM MotorPWM
        {
            get
            {
                return _motor;
            }
        }

        public Direction MotorDirection
        {
            get
            {
                return _motorDirection;
            }
            set
            {
                _motorDirection = value;
                switch (value)
                {
                    case Direction.Forward:
                        _frontDirection.Write(true);
                        break;
                    case Direction.Backward:
                        _frontDirection.Write(false);
                        break;

                }
            }
        }


    } 
}
