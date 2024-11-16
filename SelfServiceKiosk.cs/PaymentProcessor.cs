
namespace SelfServiceKiosk.cs
{
    public interface IpaymentProcessor
    {
        public double Amount { get; set; }
        void ProcessorPatment();
    }


    public class CashPaymentProcessor : IpaymentProcessor
    {
        public double Amount { get ; set ; }

        public void ProcessorPatment()
        {
            Console.WriteLine($"{Amount} miqdorida Naqt pul asosida to'lov amalga oshirilmoqda...");
        }
    }

    public class CardPaymentProcessor : IpaymentProcessor
    {
        public double Amount { get; set; }

        public void ProcessorPatment()
        {
            Console.WriteLine($"{Amount} miqdorida karta pul asosida to'lov amalga oshirilmoqda...");
        }
    }

    public class QRcodePaymentProcessor : IpaymentProcessor
    {
        public double Amount { get; set; }

        public void ProcessorPatment()
        {
            Console.WriteLine($"{Amount} QRcode asosida to'lovni amalga oshiring...");
        }
    }
}


