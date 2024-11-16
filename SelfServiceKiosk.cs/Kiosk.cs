
using SelfServiceKiosk.cs;
using static SelfServiceKiosk.cs.Contains;

namespace SelfServiceKiosk
{
    public class Kiosk
    {
        public List<Fooditem> Items { get; set; }
        public order CurrentOrder { get; set; }
        public Kiosk()
        {
            Items = new List<Fooditem>();
            Fooditem osh = new Fooditem();
            osh.Name = "Osh (polov)";
            osh.Price = 3;
            osh.Description = "guruch, sabzi,yog',go'sht";
            osh.DiscountRate = 5;
            Items.Add(osh);

            Fooditem somsa = new Fooditem();
            somsa.Name = "somsa";
            somsa.Price = 1;
            somsa.Description = "un, go'sht, piyoz,yog'";
            somsa.DiscountRate = 3;
            Items.Add(somsa);

            Fooditem lagmon = new Fooditem();
            lagmon.Name = "lagmon";
            lagmon.Price = 3;
            Items.Add(lagmon);

            Fooditem choy = new Fooditem();
            choy.Name = "choy";
            choy.Price = 0.5;
            Items.Add(choy);

            CurrentOrder = null;
        }

        public void StartNeworder()
        {
            CurrentOrder = new order();
            SetDiningOption();
        }

        private void SetDiningOption()
        {
            DiningOption diningOption;
            do
            {
            Console.WriteLine("Hizmat turini tanglang");
            Console.WriteLine("#1-restaranda ovqatlanish");
            Console.WriteLine("#2-olib ketish");
                if (DiningOption.TryParse(Console.ReadLine(), out diningOption))
                {
                    CurrentOrder.DiningOption = diningOption;
                }
                if (Enum.IsDefined(diningOption))
                {
                    break;
                }

            } while (true);
        }

        private void AddItemToOrder(Fooditem item)
        {
            CurrentOrder.Additem(item);
        }

        private void DisplayMenu()
        {
            Console.WriteLine("menyu:");
            Console.WriteLine();
            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine($"#{i + 1}.Nomi:{Items[i].Name} - Narxi: {Items[i].Price}\n {Items[i].Description}");
            }
        }

        public void TakeOrder()
        {
            Console.WriteLine("Kerakli ovqatni raqamini tanla:");
            Console.WriteLine("Buyurtmani qabul qilish uchun 0ni kiriting");
            int CustomerChoice = 0;
            do
            {
                DisplayMenu();
                int.TryParse(Console.ReadLine(), out CustomerChoice);
                if (CustomerChoice > 0 && CustomerChoice <= Items.Count)
                {
                    Fooditem chosenItem = Items[CustomerChoice - 1];
                    AddItemToOrder(chosenItem);
                }
            } while (CustomerChoice != 0);
        }
        public void CompleteOrder()
        {
            CurrentOrder.ShowPrice();
            Console.WriteLine("To'lov turini tanglang");
            Console.WriteLine("#1-Naqt pul");
            Console.WriteLine("#2-karta");
            Console.WriteLine("#3-QRcode");
            PaymentType paymentChoice = 0;
            IpaymentProcessor chosenPaymentProcessor;
            while(!Enum.TryParse(Console.ReadLine(), out paymentChoice))
            {
                Console.WriteLine("Yuqorida berilgan to'lov uslibini kiriting");
            }
            if (paymentChoice == PaymentType.Cash)
            {
                chosenPaymentProcessor = new CashPaymentProcessor();
            }
            else if (paymentChoice == PaymentType.Card)
            {
                chosenPaymentProcessor = new CardPaymentProcessor();
            }
            else if (paymentChoice == PaymentType.QRCode)
            {
                chosenPaymentProcessor = new QRcodePaymentProcessor();
            }
            else
            {
                chosenPaymentProcessor = new CashPaymentProcessor();
            }
            chosenPaymentProcessor.Amount = CurrentOrder.TotalPrice;
            CurrentOrder.SetPaymentProcessor(chosenPaymentProcessor);
            CurrentOrder.ProcessPayment();
            CurrentOrder.PrintReceipt();
        }
    }
}

