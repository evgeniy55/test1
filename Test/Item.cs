namespace Test;

internal class Item
{
    public string Name { get; set; }
    public int Weight { get; set; }

	public Item() {}

	public Item(Item other)
	{
		ArgumentNullException.ThrowIfNull(other);
		this.Name = other.Name;
		this.Weight = other.Weight;
	}
}
