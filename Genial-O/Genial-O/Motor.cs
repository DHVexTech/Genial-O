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
            _motor = new PWM(motor, 500, 0.8, true);
            _frontDirection = new OutputPort(motorFrontDirection, false);
            _motor.DutyCycle = 0.5;
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

        public void StatMotor()
        {
            Debug.Print("Duration : " + _motor.Duration.ToString());
            Debug.Print("DutyCycle : " + _motor.DutyCycle.ToString());
            Debug.Print("Frequency : " + _motor.Frequency.ToString());
            Debug.Print("Period : " + _motor.Period.ToString());
            Debug.Print("Pin : " + _motor.Pin.ToString());
            Debug.Print("Scale : " + _motor.Scale.ToString());
        }
    } 
}
