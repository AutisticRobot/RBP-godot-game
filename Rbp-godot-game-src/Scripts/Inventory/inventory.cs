using Godot;
using Godot.Collections;
using System.Collections;

[GlobalClass]
public partial class inventory : Resource, IEnumerable
{
	[Export(PropertyHint.ResourceType, "Item")] public Dictionary<int,Item> Items;

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

	public Dictionary<int, Item> ToDic()
	{
		return Items;
	}
	public void FromDic(Variant data)
	{
		Items = (Dictionary<int, Item>)data;
	}

///===================
///		Math
///===================

	public Item this[int i]
	{
		get
		{
			try
			{
			return Items[i];
			}catch{
				return new Item(i,0);
			}
		}
		set
		{
			Items[i] = value;
		}
	}	

	public void add(Item item)
	{
		if(Items[item.ID] != null)
		{
			Items[item.ID].count += item.count;
		}else{
			Items[item.ID] = item;
		}
	}

	public static inventory operator+(inventory inv1, inventory inv2)//===========================================================================NEEDS TO BE TESTED TO CONFIRM FUCINALITY!!!!
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

	public Item ElementAt(int ID)
	{
		return this[ID];
	}

    public IEnumerator GetEnumerator()
    {
		return new invEnum(this);
    }
}


 