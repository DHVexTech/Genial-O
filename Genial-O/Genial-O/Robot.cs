using System;
using Microsoft.SPOT;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Genial_O
{
    class Robot
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
            _motorRight= new Motor(PWMChannels.PWM_PIN_D10, Pins.GPIO_PIN_D0);

            _captorFront1 = new Captor(Pins.GPIO_PIN_A0, Pins.GPIO_PIN_D2);
            _captorFront2 = new Captor(Pins.GPIO_PIN_A1, Pins.GPIO_PIN_D3);
            _captorFront3 = new Captor(Pins.GPIO_PIN_A2, Pins.GPIO_PIN_D4);
            _captorRight = new Captor(Pins.GPIO_PIN_A3, Pins.GPIO_PIN_D5);
            _captorLeft = new Captor(Pins.GPIO_PIN_A4, Pins.GPIO_PIN_D6);
            _captorBack = new Captor(Pins.GPIO_PIN_A5, Pins.GPIO_PIN_D7);
        }

        public Captor CaptorFront1 => _captorFront1;

        public Captor CaptorFront2 => _captorFront2;

        public Captor CaptorFront3 => _captorFront3;

        public Captor CaptorRight => _captorRight;

        public Captor CaptorLeft => _captorLeft;

        public Captor CaptorBack => _captorBack;
                    




    }
}
