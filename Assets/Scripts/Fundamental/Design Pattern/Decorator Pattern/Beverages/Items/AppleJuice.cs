
namespace DecoratorPattern
{
    public class AppleJuice : Beverage
    {
        public AppleJuice()
        {
            description = "Apple Juice";
        }
        public override float Cost()
        {
            return 3.0f;
        }
    }

}
