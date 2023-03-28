
namespace DecoratorPattern
{
    public abstract class Beverage
    {
        protected string description = "Unknown beverage";

        public virtual string Description()
        {
            return description;
        }

        public abstract float Cost();        
               
    }

}
