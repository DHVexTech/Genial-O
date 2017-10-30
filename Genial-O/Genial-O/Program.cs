using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Genial_O
{
    public class Program
    {
        public static void Main()
        {
            // write your code here
            
            Robot robot = new Robot();
            //Captor captorFront = new Captor(Pins.GPIO_PIN_D4, Pins.GPIO_PIN_D5);

            

            OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);

            // run forever
            while (true)
            {
                Debug.Print("Front 1 : " + robot.CaptorFront1.Ping().ToString());
                Debug.Print("Front 2 : " + robot.CaptorFront2.Ping().ToString());
                Debug.Print("Front 3 : " + robot.CaptorFront3.Ping().ToString());
                Debug.Print("Right : " + robot.CaptorRight.Ping().ToString());
                Debug.Print("Left : " + robot.CaptorLeft.Ping().ToString());
                //Debug.Print("Back : " + robot.CaptorBack.Ping().ToString());

                Thread.Sleep(500);
                led.Write(true); // turn on the LED
                Thread.Sleep(250); // sleep for 250ms
                led.Write(false); // turn off the LED
                Thread.Sleep(250); // sleep for 250ms


            }
        }

    }
}
