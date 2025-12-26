namespace Test;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

		var inv = new Inventory();
		var i1 = new Item() { Name = "Book", Weight = 5 };
		var i2 = new Item() { Name = "Key", Weight = 1 };
		var i31 = new Item() { Name = "Tomato", Weight = 3 };
		var i32 = new Item() { Name = "Tomato", Weight = 5 };

		inv.AddItem(i1);
		inv.AddItem(i2);
		inv.AddItem(i31);
		inv.AddItem(i32);

		var items = inv.Items;

		var f1 = items.First();
		f1.Name = "123";

		inv.RemoveItem(i32);

		var fitems = inv.FindItems("tom");
	}
}
