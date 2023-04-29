using System;

namespace DecoratorPatternExample
{
    public class TeaWithSugar : TeaDecorator
    {
        public int SugarSpoons { get; set; }
        public TeaWithSugar(Tea tea, int sugarSpoons = 1) : base(tea.Name + " with sugar", tea)
        {
            SugarSpoons = sugarSpoons;
        }
        public override void BrewTea()
        {
            _tea.BrewTea();
            Console.WriteLine("Adding " + SugarSpoons + " spoons of sugar.");
        }

        public override void SetRatio(double water, double tea)
        {
            _tea.SetRatio(water, tea);
        }
    }
}
