using Godot;
using Godot.Collections;
using System.Collections;

[GlobalClass]
public partial class inventory : Resource, IEnumerable
{
	[Export] public Item[] inItems;
	[Export] public Dictionary<int,Item> Items;

	public int Count;


///===================
///	   Constructor
///===================
public inventory()
{
	Items = new();
}

///===================
///		Save/Load  
///===================

    static public explicit operator string(inventory inv)
	{
		return null;//(Dictionary)Items;
	}
    static public explicit operator inventory(Variant inv)
	{
		return null;
		//Items = (Dictionary<int,Item>)data;
		//GD.Print("Items Dic: " + data);
	}
	public string ToData()
	{
		return (string)this;
	}
	public void FromData(Variant data)
	{
		inventory inv = new();

		try
		{
			inv.Free();
			inv = (inventory)data;
	
			inItems = inv.inItems;
			Items = inv.Items;
			Count = inv.Count;

		}catch{

		}
		inv.Free();

	}

	

///===================
///		Math
///===================

	public Item this[int ID]
	{
		get
		{
			try
			{
			return Items[ID];
			}catch{
				return new Item(ID,0);
			}
		}
		set
		{
			Items[ID] = value;
		}
	}	

	public void add(Item item)
	{
		if(Items.ContainsKey(item.ID))
		{
			(Items[item.ID]).count += item.count;
		}else{
			Items[item.ID] = item;
			Count++;
		}
	}

	public static inventory operator+(inventory inv1, inventory inv2)
	{

		foreach (Item item in inv2)
		{
			inv1.add(item);
		}

		return inv1;
		
	}

///===================
///		Other
///===================

	public int updateCount()
	{
		return Count = Items.Count;
	}

	public Item ElementAt(int ID)
	{
		return this[ID];
	}

    public IEnumerator GetEnumerator()
    {
		return new invEnum(this);
    }
}


 