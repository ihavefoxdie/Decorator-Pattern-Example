using System.Threading;

namespace DecoratorPatternExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RealTea realTea = new(2, "Black");
            TeaProxy teaProxy = new(realTea, 10);
            Thread thread1 = new(teaProxy.BoilWater);
            thread1.Start();
            System.Console.WriteLine("Started water boiling process.\n");
            while(true)
            {
                System.Console.WriteLine("Water temperature: " + teaProxy.WaterTemp);
                Thread.Sleep(2500);
                if(teaProxy.BrewTea())
                {
                    System.Console.WriteLine("Water temperature: " + teaProxy.WaterTemp);
                    break;
                }
            }
            
        }
    }
}
