using Godot;
using Godot.Collections;
using System;
using System.Collections;

[GlobalClass]
public partial class ShopInventory : inventory
{	
	//[Export] new public Dictionary<int,ShopItem> Items;

///===================
///		Save/Load
///===================

	new public string ToData()
	{
		return null;//Items.ToString();
	}
	new public void FromData(Variant data)
	{
		GD.Print("shopInv Load Blocked");
		//Items = (Dictionary<int, ShopItem>)data;
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
			return (ShopItem)Items[i];
			}catch{
				return null;
			}
		}
		set
		{
			Items[i] = value;
		}
	}	

	public void add(ShopItem item)
	{
			GD.Print("shopInv Add");
		if(Items.ContainsKey(item.ID))
		{
			Items[item.ID].count += item.count;
		}else{
			Items[item.ID] = item;
			Count++;
		}
	}
	new public void add(Item item)
	{
			GD.Print("shopInv Add Item");
		if(Items[item.ID] != null)
		{
			Items[item.ID].count += item.count;
		}else{
            Items[item.ID] = new()
            {
                ID = item.ID,
                count = item.count
            };
        }
	}

/*
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

*/
}
