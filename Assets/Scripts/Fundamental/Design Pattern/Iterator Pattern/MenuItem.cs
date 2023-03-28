
namespace IteratorPattern
{
    public class MenuItem 
    {
        public string Name;
        public string Description;
        public bool Vegetarian;
        public float Price;

        public MenuItem(string name,string  description,bool vegetarian, float price)
        {
            Name = name;
            Description = description;
            Vegetarian = vegetarian;
            Price = price;
        }

        public string getName()
        {
            return Name;
        }

        public string getDescription()
        {
            return Description;
        }

        public double getPrice()
        {
            return Price;
        }

        public bool isVegetarian()
        {
            return Vegetarian;
        }
        public string toString()
        {
            return (Name + ", $" + Price + "\n   " + Description);
        }
    }
}
