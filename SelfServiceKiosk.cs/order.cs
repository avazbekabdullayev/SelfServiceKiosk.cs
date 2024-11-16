namespace SelfServiceKiosk.cs
{
    public class order
    {
        public order()
        {
            Init();
        }

        private void Init()
        {
            Items = new List<Fooditem>();
            TotalPrice = 0;
            date = DateTime.Now;
            OrderQueueNumber = GenerateQueueNumber();
        }

        public List<Fooditem> Items { get; set; }
        public double TotalPrice  { get; set; }
        public int OrderQueueNumber { get; set; }
        public DateTime date { get; set; }
        public IpaymentProcessor PaymentProcessor { get; set; }
        public Contains.DiningOption DiningOption { get;  set; }

        public void Additem(Fooditem fooditem)
        {
            Items.Add(fooditem);
            TotalPrice += fooditem.ApplyDiscount();
        }

        public void SetPaymentProcessor(IpaymentProcessor paymentprocessor)
        {
            PaymentProcessor = paymentprocessor;
        }

        public  void ProcessPayment()
        {
            if (PaymentProcessor != null)  PaymentProcessor.ProcessorPatment();
            else Console.WriteLine("To'lovni amalga oshirish uslubi aniqlanmagan");
        }

        public void PrintReceipt()
        {
            Console.WriteLine("Checkni chiqarilmoqda...");
            Console.WriteLine($"Navbat raqami: {OrderQueueNumber}");
            Console.WriteLine($"hizmat turi {DiningOption.ToString()}");
        }

        public void ShowPrice()
        {
            foreach (var item in Items)
            {
                Console.WriteLine($"Nomi: {item.Name} - Narxi:{item.Price}$");
            }
            Console.WriteLine($"Jami narxi:{TotalPrice}$");
        }

        private int GenerateQueueNumber()
        {
         Random rnd = new Random();
         return rnd.Next(1000, 10000);
        }

    }       
}
