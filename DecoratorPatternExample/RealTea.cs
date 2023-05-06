using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternExample
{
    public class RealTea : Tea
    {
        public int SugarSpoons { get; set; }
        public string Name { get; private set; }

        public RealTea(int sugarSpoons, string name)
        {
            SugarSpoons = sugarSpoons;
            Name = name;
        }
        public bool BrewTea()
        {
            Console.WriteLine("Brewing " + Name + " tea with " + SugarSpoons + " sugar spoons.");
            return true;
        }
    }
}
