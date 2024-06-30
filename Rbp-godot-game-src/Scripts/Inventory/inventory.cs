using Godot;
using Godot.Collections;
using System;
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
    static public explicit operator inventory(string inv)
	{
		inventory outinv = new();
		string inStr = inv;

		inStr = inStr.Substr(1,inStr.Length - 2);
		//GD.Print("inv from str:" + inStr);
		string[] allPart = inStr.Split(",");

		foreach(string str in allPart)//reuses inStr as first item part to try and save on some minor memory;
		{
			if(str[0] == '(')
			{
				inStr = str;
			}else{
				outinv.add((Item)(inStr + "," + str));
			}
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
	public static inventory operator+(inventory inv, Item item)
	{
		inv.add(item);
		return inv;
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


 