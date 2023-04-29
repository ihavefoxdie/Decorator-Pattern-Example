using System;

namespace DecoratorPatternExample
{
    public class MintTea : TeaDecorator
    {
        public MintTea(Tea tea, int mintLeaves = 1) : base(tea.Name + " with mint", tea)
        {
            MintLeaves = mintLeaves;
        }

        public int MintLeaves { get; set; }
        public override void BrewTea()
        {
            _tea.BrewTea();
            Console.WriteLine("Adding " + MintLeaves.ToString() + " mint leaves to the concoction.");
        }

        public override void SetRatio(double water, double tea)
        {
            _tea.SetRatio(water, tea);
        }
    }
}
