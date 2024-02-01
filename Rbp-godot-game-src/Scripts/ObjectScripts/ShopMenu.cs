using Godot;
using System;
using System.Linq;

public partial class ShopMenu : Control
{
	[Export]
	public ShopInventory shop;
	[Export]
	public inventory player;
	[Export]
	public int buyMulti;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		shop = GetChild<ShopInventory>(0);
		player = GetChild<inventory>(1);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void exchange(bool isBuy, string type)
	{

	}

	public int getShopInv(string type, int valState)
	{
		return 0;
	}
	public int getPlayerInv(string type)
	{
		return 0;
	}

}
