namespace DecoratorPatternExample
{
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
}
