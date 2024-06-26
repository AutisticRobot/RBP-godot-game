using Godot;
using Godot.Collections;
using System.Collections;

[GlobalClass]
public partial class inventory : Resource, IEnumerable
{
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
///		Save/Load  !!!!!!!!!!!!!!!SAVE/LOAD BROKEN FOR ITEMS!!!!!!!!!!!!!
///===================

	public Dictionary ToDic()// untyped dictionary because type dosent matter until load.
	{
		return null;
	}
	public void FromDic(Variant data)
	{
		//Items = (Dictionary<int,Item>)data;
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


 