using Godot;
using System;

public partial class shopObject : Sprite2D
{
	[Export] public string ShopID;
	[Export] public ShopInventory hardInv {get;private set;}
			 public ShopInventory inv = new();
	[Export] public ShopModRes modPrice;


	[Signal] public delegate Signal shopOpenEventHandler(ShopInventory shopInv);
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void onShopOpen()
	{
		hardInv.flushInItems();
		inv = hardInv;
		inv = modPrice.Mod((ShopInventory)hardInv.Duplicate(true));
		inv.flushInItems();
		if(hardInv[1] != null){GD.Print("hardInv:" + hardInv[1].SellPrice);}
		EmitSignal(SignalName.shopOpen, inv);
	}
}
