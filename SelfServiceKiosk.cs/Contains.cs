namespace SelfServiceKiosk.cs
{
    public class Contains
    {
        public enum PaymentType : short
        {
            Cash = 1,
            Card = 2,
            QRCode = 3,
        }

        public enum DiningOption : short
        { 
            DineIn = 1,
            Takeaway = 2,
        }
    }

}
