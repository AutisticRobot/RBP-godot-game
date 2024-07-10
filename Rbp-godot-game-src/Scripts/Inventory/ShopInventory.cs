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

    static public explicit operator string(ShopInventory inv)
	{
		string outstr = "(";
		foreach(Item i in inv)
		{
			outstr += (string)i + ",";
		}
		outstr = outstr.Remove(outstr.Length - 1);
		return outstr + ")";
	}
    static public explicit operator ShopInventory(string inv)
	{
		ShopInventory outinv = new();
		string inStr = inv;

		inStr = inStr.Substr(2,inStr.Length - 4);
		//GD.Print("inv from str:" + inStr);
		string[] allPart = inStr.Split("),(");

		foreach(string str in allPart)
		{
				outinv.add((ShopItem)("(" + str + ")"));
		}

		return outinv;
	}
	new public string ToData()
	{
		return (string)this;
	}
	new public void FromData(Variant data)
	{
		ShopInventory inv = new();

		try
		{
			inv = (ShopInventory)(string)data;
	
			Items = inv.Items;
			inItems = inv.inItems;
			Count = inv.Count;

			flushInItems();

		}catch(Exception e){

			GD.Print(e);
			GD.Print(data);
			GD.Print("INv From Data broke");
		}
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
