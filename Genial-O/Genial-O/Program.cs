using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using Genial_O.HttpServer;

namespace Genial_O
{
    public class Program
    {
        public static void Main()
        {
            // write your code here

            Robot robot = new Robot();

            Thread serverThread = new Thread(() =>
            {
                Server server = new Server();
                server.ListenForRequest();
            });

            serverThread.Start();

            OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);

            // run forever
            while (true)
            {
                robot.GoLeft();
                Debug.Print(robot.MotorLeft.MotorPWM.DutyCycle.ToString());
                Thread.Sleep(500);
                led.Write(true); // turn on the LED
                Thread.Sleep(250); // sleep for 250ms
                led.Write(false); // turn off the LED
                Thread.Sleep(250); // sleep for 250ms
            }
        }

    }
}
