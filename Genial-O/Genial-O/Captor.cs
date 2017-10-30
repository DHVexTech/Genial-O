using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;

namespace Genial_O
{
    public class Captor
    {
        private OutputPort portOut;
        private InterruptPort interIn;
        private long beginTick;
        private long endTick;
        private long minTicks = 0;

        public Captor(Cpu.Pin pinTrig, Cpu.Pin pinEcho)
        {
            portOut = new OutputPort(pinTrig, false);
            interIn = new InterruptPort(pinEcho, false, Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeLow);

            interIn.OnInterrupt += new NativeEventHandler(interIn_OnInterrupt);
            minTicks = 4000L;
        }

        public long Ping()
        {
            portOut.Write(true);
            Thread.Sleep(1);

            endTick = 0L;
            beginTick = DateTime.Now.Ticks;
            portOut.Write(false);

            Thread.Sleep(50);

            if (endTick > 0L)
            {
                long elapsed = endTick - beginTick;

                elapsed -= minTicks;
                if (elapsed < 0L)
                {
                    elapsed = 0L;
                }

                return elapsed / 636;
            }
            return -1L;
        }

        void interIn_OnInterrupt(uint data1, uint data2, System.DateTime time)
        {
            endTick = time.Ticks;
        }


    }
}
