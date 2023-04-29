using System;

namespace DecoratorPatternExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CeylonTea tea = new(0.25f);
            Console.WriteLine("Name: " + tea.Name);
            tea.BrewTea();

            Console.WriteLine("\nDecorator: ");
            MintTea mintTea = new(tea, 2);
            Console.WriteLine("Name: " + mintTea.Name);
            mintTea.BrewTea();

            Console.WriteLine("\n2nd decorator: ");
            TeaWithSugar sugarTea = new(mintTea, 2);
            Console.WriteLine("Name: " + sugarTea.Name);
            sugarTea.BrewTea();
        }
    }

    public abstract class Tea
    {
        public string Name { get; protected set; }
        public double TeaToWaterRatio { get; protected set; }
        public abstract void BrewTea();

        public Tea(string name, double teaToWaterRatio)
        {
            Name = name;
            TeaToWaterRatio = teaToWaterRatio;
        }
        public Tea(string name)
        {
            Name = name;
        }
        public abstract void SetRatio(double water, double tea);
    }

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

    public abstract class TeaDecorator : Tea
    {
        protected Tea _tea;
        public TeaDecorator(string name, Tea tea) : base(name, tea.TeaToWaterRatio)
        {
            _tea = tea;
        }
    }

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
