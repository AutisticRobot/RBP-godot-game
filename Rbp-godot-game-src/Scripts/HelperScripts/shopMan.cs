using Godot;
using Godot.Collections;
using System.Collections.Generic;

public partial class shopMan : Node
{
	[Export] public priceModulator priceMod;

	public List<shopObject> allShops = new();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		fillShopsList();
	}

	private void fillShopsList()
	{


        foreach(Node child in GetChildren())
        {
            GD.Print(child.GetClass());
            if(child.GetType().ToString() == "shopObject")
            {
                allShops.Add((shopObject)GetChild(child.GetIndex()));
            }
        }
	}

	public Dictionary getShposSaveData()
	{
		Dictionary data = new();

		foreach(shopObject shop in allShops)
		{
			data.Add(shop.ShopID, shop.inv.ToData());
		}

		return data;

	}
	public void loadShopsSaveData(Dictionary Data)
	{
		if(allShops.Count == 0) {fillShopsList();}
		foreach(shopObject shop in allShops)
		{
			Dictionary shopData = (Dictionary)Data[shop.ShopID];
			if(shopData != null)
			{
				shop.inv.FromData(shopData);
			}
		}

	}
	public void modShopData()
	{
		if(allShops.Count == 0) {fillShopsList();}
		foreach(shopObject shop in allShops)
		{
			shop.inv = priceMod.simpleMod(shop.inv);
		}
	}

}
