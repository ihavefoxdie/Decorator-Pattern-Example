using System.Threading;

namespace DecoratorPatternExample
{
    public sealed class TeaProxy : Tea
    {
        private Tea _tea;
        object _lockObj = new();
        object _lockObj2 = new();
        private Thread _thread;


        public float WaterInL { get; set; }
        public int WaterTemp { get; private set; } = 10;
        

        public TeaProxy(Tea tea, int waterInL)
        {
            _tea = tea;
            WaterInL = waterInL;
            _thread = new(WaterTempDrop)
            {
                IsBackground = true
            };
            _thread.Start();
        }

        public void BoilWater()
        {
            lock (_lockObj2)
            {
                for (; WaterTemp < 100;)
                {
                    WaterTemp += 1;
                    Thread.Sleep(100);
                }
            }
        }

        public bool BrewTea()
        {
            if (WaterInL > 0 && WaterTemp >= 90)
            {
                WaterInL -= 0.3f;
                return _tea.BrewTea();
            }
            return false;
        }

        private void WaterTempDrop()
        {
            lock (_lockObj)
            {
                while (true)
                {
                    if (WaterTemp > 10)
                        WaterTemp -= 2;
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
