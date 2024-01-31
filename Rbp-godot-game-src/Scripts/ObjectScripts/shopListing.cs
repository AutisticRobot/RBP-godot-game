using Godot;
using System;

public partial class shopListing : Sprite2D
{
	[Export]
	public ShopMenu shopMan;
	[Export]
	public string type;


	public override void _Ready()
	{
		shopMan = GetParent<ShopMenu>();
	}

	public void Buy()
	{
		shopMan.exchange(true, type);
	}
	public void Sell()
	{
		shopMan.exchange(false, type);
	}
}
