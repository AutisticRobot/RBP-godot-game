using Godot;
using System;
using System.Diagnostics;

public partial class shopListing : Sprite2D
{
	[Export] public ShopMenu shopMan;
	[Export] private int itemID;//========If this needs to be changed, use UpdateItems();
	[Export] public Label playerStock;
	[Export] public Label buyPrice;
	[Export] public Label sellPrice;
	[Export] public Label shopStock;
			 public ShopItem shopitem;
			 public Item playerItem;
	[Export] public bool onlyShow;


	public override void _Ready()
	{
		shopMan = GetOwner<ShopMenu>();

	}

	
	public override void _Process(double delta)
	{
		if(shopMan.Visible)
		{
			UpdateItems(itemID);

			Update();
		}
	}

	public void Update()
	{
		if(shopitem != null && playerItem != null)
		{

			playerStock.Text = playerItem.count.ToString();
			shopStock.Text = shopitem.count.ToString();
			if(!onlyShow)
			{
				buyPrice.Text = "$" +  shopitem.buyPrice.ToString();
				sellPrice.Text = "$" + shopitem.SellPrice.ToString();
			}
		}else{
			Visible = false;
		}
	}

	public void UpdateItems(int newItemID)
	{
		shopitem = shopMan.GetShopInv(newItemID);
		playerItem = shopMan.GetPlayerInv(newItemID);
	}

	public void Buy()
	{
		GD.Print("Buy");
		shopMan.Exchange(true, itemID);
	}
	public void Sell()
	{
		GD.Print("Sell");
		shopMan.Exchange(false, itemID);
	}
}
