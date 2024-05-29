using Godot;
using Godot.Collections;
using System.Collections;

[GlobalClass]
public partial class inventory : Resource, IEnumerable
{
	[Export] public Dictionary<int,Item> Items;


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
			return Items[i];
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

    public IEnumerator GetEnumerator()
    {
		return new ItemEnum(Items);
    }
}


 