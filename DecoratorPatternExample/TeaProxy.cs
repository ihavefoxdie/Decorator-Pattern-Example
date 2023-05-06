using System.Threading;

namespace DecoratorPatternExample
{
    public sealed class TeaProxy : Tea
    {
        private Tea _tea;
        public float WaterInL { get; set; }
        public int WaterTemp { get; private set; } = 10;
        private Thread _thread;
        public TeaProxy(Tea tea, int waterInL)
        {
            _tea = tea;
            WaterInL = waterInL;
            _thread = new(this.WaterTempDrop);
            _thread.IsBackground = true;
            _thread.Start();
        }

        public void BoilWater()
        {
            for (; WaterTemp < 100;)
            {
                    WaterTemp += 1;
                Thread.Sleep(100);
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

        public void WaterTempDrop()
        {
            while (true)
            {
                if (WaterTemp > 10)
                    WaterTemp--;
                Thread.Sleep(1000);
            }
        }
    }
}
