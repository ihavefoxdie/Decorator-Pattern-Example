namespace DecoratorPatternExample
{
    public abstract class TeaDecorator : Tea
    {
        protected Tea _tea;
        public TeaDecorator(string name, Tea tea) : base(name, tea.TeaToWaterRatio)
        {
            _tea = tea;
        }
    }
}
