

namespace DecoratorPattern
{
    public class Milk : Decorator
    {
        Beverage beverage;

        public Milk(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string Description()
        {
            return beverage.Description() + " +Milk";
        }

        public override float Cost()
        {
            return beverage.Cost() + 0.2f;
        }

    }

}
