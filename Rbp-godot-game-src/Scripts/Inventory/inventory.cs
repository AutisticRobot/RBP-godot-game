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
		string outstr = "(";
		foreach(Item i in inv)
		{
			outstr += (string)i + ",";
		}
		outstr = outstr.Remove(outstr.Length - 1);
		return outstr + ")";
	}
    static public explicit operator inventory(Variant inv)
	{
		return new();
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
			inv = (inventory)data;
	
			GD.Print(inItems.Length);
			inItems = inv.inItems;
			Count = inv.Count;


		}catch{
			GD.Print("INv From Data broke");
		}

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


 