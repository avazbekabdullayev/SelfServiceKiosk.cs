namespace SelfServiceKiosk.cs
{
    public class Fooditem :IDiscountable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double DiscountRate { get; set; } = 0;

        public double ApplyDiscount()
        {
           return Price - (Price * DiscountRate/100);
        }
    }

    public interface IDiscountable
    {
        double Price { get; set; }
        double DiscountRate {  get; set; }
        double ApplyDiscount();
    }
}
