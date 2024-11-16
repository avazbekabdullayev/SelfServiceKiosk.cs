using SelfServiceKiosk;
using SelfServiceKiosk.cs;
while (true)
{
	Console.WriteLine("###################");
	Console.WriteLine("VD restoronoga cush kelibsiz");
	Kiosk kiosk = new();
	kiosk.StartNeworder();
	kiosk.TakeOrder();
	kiosk.CompleteOrder();
	Console.WriteLine("Buyurtma yakunlandi");
	Console.WriteLine("--------------------");
	Console.WriteLine("");
}