using Godot;
using Godot.Collections;
using System;
using System.Collections;

[GlobalClass]
public partial class ShopInventory : inventory
{	
	[Export] new public Godot.Collections.Dictionary<int,ShopItem> Items;

///===================
///		Save/Load
///===================

	new public Dictionary<int, ShopItem> ToDic()
	{
		return Items;
	}
	new public void FromDic(Variant data)
	{
		Items = (Dictionary<int, ShopItem>)data;
	}

///===================
///		Math
///===================

	new public ShopItem this[int i]
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

	public void add(ShopItem item)
	{
		if(Items[item.ID] != null)
		{
			Items[item.ID].count += item.count;
		}else{
			Items[item.ID] = item;
		}
	}

	public static ShopInventory operator+(ShopInventory inv1, ShopInventory inv2)//===========================================================================NEEDS TO BE TESTED TO CONFIRM FUCINALITY!!!!
	{

		foreach (ShopItem item in inv2)
		{
			inv1.add(item);
		}

		return inv1;
		
	}
	

    new public IEnumerator GetEnumerator()
    {
		return new ShopItemEnum(Items);
    }


}