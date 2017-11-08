using System;
using System.Collections;
using Microsoft.SPOT;

namespace Genial_O
{
    public class DetectObstacle
    {
        private readonly Robot _robot;
        private ArrayList obstacles;

        public DetectObstacle(Robot robot)
        {
            _robot = robot;
        }


        public void SensorLoop()
        {
            
            while (true)
            {
                if(CheckValue(_robot.CaptorFront2))
                {
                    Obstacle obstacle = new Obstacle(Guid.NewGuid(), new Vector(0,0));
                    if(!CheckValue(_robot.CaptorFront1))
                    {
                        // Go Left
                    }
                    else if (!CheckValue(_robot.CaptorFront3))
                    {
                        // Go Right
                    }
                }
            }
        }

        public Captor CompareSensor(Captor sensor, Captor sensor1)
        {
            return sensor.Ping().ToString() == "-1" || int.Parse(sensor.Ping().ToString()) > int.Parse(sensor1.Ping().ToString()) ? sensor : sensor1;
        }

        public bool CheckValue(Captor sensor)
        {
            int y = 0;
            int value1 = -1;
            
            for (int i = 0; i < 3; i++)
            {
                int valueSensor = int.Parse(sensor.PositionSensor.ToString());
                if (valueSensor <= value1)
                {
                    value1 = valueSensor;
                    y++;
                }
            }

            return y == 2 ? true : false;          
        }
    }


}
