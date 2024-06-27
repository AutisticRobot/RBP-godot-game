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

	new public string ToData()
	{
		return Items.ToString();
	}
	new public void FromData(Variant data)
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
			try
			{
			return Items[i];
			}catch{
				return new ShopItem(i,0);
			}
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
		return new invEnum(this);
    }


}
