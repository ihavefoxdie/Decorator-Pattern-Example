using System.Diagnostics;
using System.Threading;

namespace DecoratorPatternExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RealTea realTea = new(2, "Black");
            TeaProxy teaProxy = new(realTea, 10);
            Thread thread = new(teaProxy.BoilWater);
            thread.Start();

            System.Console.WriteLine("Started water boiling process.\n");
            while (!teaProxy.BrewTea())
            {
                System.Console.WriteLine("Water temperature: " + teaProxy.WaterTemp);
                Thread.Sleep(1000);
            }

        }
    }
}
