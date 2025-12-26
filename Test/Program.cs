namespace Test;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

		var inv = new Inventory();
		var i1 = new Item() { Name = "I1", Weight = 5 };
		var i2 = new Item() { Name = "I2", Weight = 6 };
		var i22 = new Item() { Name = "I2", Weight = 3 };
		inv.AddItem(i1);
		inv.AddItem(i2);
		inv.AddItem(i22);

		var items = inv.Items;

		var f1 = items.First();
		f1.Name = "123";

		inv.RemoveItem(i22);
	}
}
