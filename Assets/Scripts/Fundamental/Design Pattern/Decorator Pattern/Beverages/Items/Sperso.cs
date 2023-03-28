
namespace DecoratorPattern
{
    public class Sperso : Beverage
    {
        public Sperso()
        {
            description = "Sperso Coffee";
        }
        public override float Cost()
        {
            return 1.5f;
        }
    }
}
