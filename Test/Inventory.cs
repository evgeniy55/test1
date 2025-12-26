using System.Collections.Generic;

namespace Test;

internal class Inventory
{
	private readonly List<Item> _items = [];
	private int _currentWeight = 0;

	public int MaxWeight => maxWeight;
	public int CurrentWeight
	{
		get { lock (_lock) return _currentWeight; }
	}

	private readonly object _lock = new object();
	private readonly int maxWeight = 100;

	public IReadOnlyList<Item> Items
	{
		get
		{
			lock (_lock)
			{
				var newItems = new List<Item>(_items.Count);
				foreach (var item in _items){
					newItems.Add(new Item(item));
				}
				return newItems;
			}
		}
	}

	public void AddItem(Item item)
	{
		ArgumentNullException.ThrowIfNull(item);

		lock (_lock)
		{
			if (_currentWeight + item.Weight > MaxWeight)
			{
				throw new ArgumentOutOfRangeException(nameof(item.Weight), $"Max weight is {MaxWeight}");
			}

			var fitem = _items.FirstOrDefault(f => f.Name == item.Name);
			if (fitem == null)
			{
				_items.Add(item);
				_currentWeight += item.Weight;
			}
			else
			{
				fitem.Weight += item.Weight;
				_currentWeight += item.Weight;
			}
		}
	}

	public bool RemoveItem(Item item)
	{
		ArgumentNullException.ThrowIfNull(item);

		lock (_lock)
		{
			var fitem = _items.FirstOrDefault(f => f.Name == item.Name);
			if (fitem != null && fitem.Weight >= item.Weight)
			{
				fitem.Weight -= item.Weight;
				if (fitem.Weight <= 0)
				{
					_items.Remove(fitem);
				}
				_currentWeight -= item.Weight;
				return true;
			}
			return false;
		}
	}

	public IReadOnlyList<Item> FindItems(string name)
	{
		lock (_lock)
		{
			var findedItems = new List<Item>();
			foreach (var item in _items)
			{
				if (item.Name.Contains(name))
				{
					findedItems.Add(item);
				}
			}
			return findedItems.AsReadOnly();
		}
	}
}
