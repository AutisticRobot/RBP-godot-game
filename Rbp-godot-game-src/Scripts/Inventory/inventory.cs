using Godot;
using Godot.Collections;
using System;
using System.Collections;

[GlobalClass]
public partial class inventory : Resource, IEnumerable
{
	[Export] public Item[] inItems;
			 public Dictionary<int,Item> Items;

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
    static public explicit operator inventory(string inv)
	{
		if(inv.Length <= 2)
		{
			return null;
		}
		inventory outinv = new();
		string inStr = inv;

		inStr = inStr.Substr(2,inStr.Length - 4);
		//GD.Print("inv from str:" + inStr);
		string[] allPart = inStr.Split("),(");

		foreach(string str in allPart)
		{
				outinv.add((Item)("(" + str + ")"));
		}

		return outinv;
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
			inv = (inventory)(string)data;

			if(inv == null)
			{
				Items = new();
				return;
				}
	
			Items = inv.Items;
			inItems = inv.inItems;
			Count = inv.Count;

			flushInItems();

		}catch(Exception e){

			GD.Print(e);
			GD.Print(data);
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
				return null;
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
	public static inventory operator+(inventory inv, Item item)
	{
		inv.add(item);
		return inv;
	}
	public static inventory operator-(inventory inv1, inventory inv2)
	{

		foreach (Item item in inv2)
		{
			item.count = -item.count;
			inv1.add(item);
		}

		return inv1;
	}
		

///===================
///		Other
///===================

	public void flushInItems()
	{
		if(inItems != null)
		{
			foreach(Item i in inItems)
			{
				add(i);
			}

			inItems = null;
			GD.Print("inItems flushed");
		}else{
			GD.Print("Intems is null");
		}
		updateCount();
	}

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


 