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
}
