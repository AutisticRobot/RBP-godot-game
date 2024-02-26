using Godot;
using System;
using System.Diagnostics;

public partial class shopListing : Sprite2D
{
	[Export] public ShopMenu shopMan;
	[Export] public string type;
	[Export] public Label playerStock;
	[Export] public Label buyPrice;
	[Export] public Label sellPrice;
	[Export] public Label shopStock;
	[Export] public bool onlyShow;


	public override void _Ready()
	{
		shopMan = GetParent<ShopMenu>();

	}

	
	public override void _Process(double delta)
	{
		Update();
	}

	public void Update()
	{
		playerStock.Text = shopMan.GetPlayerInv(type).ToString();
		shopStock.Text = shopMan.GetShopInv(type, 0).ToString();
		if(!onlyShow)
		{
			buyPrice.Text = shopMan.GetShopInv(type, 1).ToString();
			sellPrice.Text = shopMan.GetShopInv(type, 2).ToString();
		}
	}

	public void Buy()
	{
		GD.Print("Buy");
		shopMan.Exchange(true, type);
	}
	public void Sell()
	{
		GD.Print("Sell");
		shopMan.Exchange(false, type);
	}
}
