using System;
using Microsoft.SPOT;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Genial_O
{
    public class Robot
    {
        private readonly Motor _motorRight;
        private readonly Motor _motorLeft;
        private readonly Captor _captorFront1;
        private readonly Captor _captorFront2;
        private readonly Captor _captorFront3;
        private readonly Captor _captorBack;
        private readonly Captor _captorRight;
        private readonly Captor _captorLeft;


        public Robot()
        {
            _motorLeft = new Motor(PWMChannels.PWM_PIN_D9, Pins.GPIO_PIN_D1);
            _motorRight= new Motor(PWMChannels.PWM_PIN_D11, Pins.GPIO_PIN_D12);

            _captorFront1 = new Captor(Pins.GPIO_PIN_A0, Pins.GPIO_PIN_D2, PositionSensor.FrontLeft);
            _captorFront2 = new Captor(Pins.GPIO_PIN_A1, Pins.GPIO_PIN_D3, PositionSensor.Front);
            _captorFront3 = new Captor(Pins.GPIO_PIN_A2, Pins.GPIO_PIN_D4, PositionSensor.FrontRight);
            _captorRight = new Captor(Pins.GPIO_PIN_A3, Pins.GPIO_PIN_D5, PositionSensor.Right);
            _captorLeft = new Captor(Pins.GPIO_PIN_A4, Pins.GPIO_PIN_D6, PositionSensor.Left);
            _captorBack = new Captor(Pins.GPIO_PIN_A5, Pins.GPIO_PIN_D7, PositionSensor.Back);
        }

        public Captor CaptorFront1
        {
            get
            {
                return _captorFront1;
            }
        }

        public Captor CaptorFront2
        {
            get
            {
                return _captorFront2;
            }
        }

        public Captor CaptorFront3
        {
            get
            {
                return _captorFront3;
            }
        }

        public Captor CaptorRight
        {
            get
            {
                return _captorRight;
            }
        }

        public Captor CaptorLeft
        {
            get
            {
                return _captorLeft;
            }
        }

        public Captor CaptorBack
        {
            get
            {
                return _captorBack;
            }
        }

        public Motor MotorLeft
        {
            get
            {
                return _motorLeft;
            }
        }

        public Motor MotorRight
        {
            get
            {
                return _motorRight;
            }
        }
                    

        public void GoBackward()
        {
            _motorLeft.MotorDirection = Direction.Backward;
            _motorRight.MotorDirection = Direction.Backward;
            StartMotor();
        }

        public void GoForward()
        {
            _motorLeft.MotorDirection = Direction.Forward;
            _motorRight.MotorDirection = Direction.Forward;
            StartMotor();
        }

        public void GoRight()
        {
            _motorLeft.MotorDirection = Direction.Forward;
            _motorRight.MotorDirection = Direction.Backward;
            StartMotor();
        }

        public void GoLeft()
        {
            //  _motorRight.MotorPWM.DutyCycle = 1;
            _motorLeft.MotorDirection = Direction.Forward;
            _motorRight.MotorDirection = Direction.Forward;
            StartMotor();
        }

        private void StartMotor()
        {
            _motorLeft.MotorPWM.Start();
            _motorRight.MotorPWM.Start();
        }

        private void StopMotor()
        {
            _motorLeft.MotorPWM.Stop();
            _motorRight.MotorPWM.Stop();
        }

    }
}
