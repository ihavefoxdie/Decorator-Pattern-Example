using System;

namespace DecoratorPatternExample
{
    public class CeylonTea : Tea
    {
        public CeylonTea() : base("Ceylon Tea")
        {
        }
        public CeylonTea(double ratio) : base("Ceylon Tea", ratio)
        {

        }
        public override void BrewTea()
        {
            if (TeaToWaterRatio != 0)
                Console.WriteLine("Brewing " + Name + " with " + TeaToWaterRatio.ToString() + " tea to water ratio.");
            else
                Console.WriteLine("Tea to water ratio is not set.");
        }
        public override void SetRatio(double water, double tea)
        {
            TeaToWaterRatio = water / tea;
        }
    }
}
