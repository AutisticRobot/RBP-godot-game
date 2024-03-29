using Godot;
using System;

public partial class GrayBoxDirama : Node2D
{
	[Signal] public delegate Signal shopOpenEventHandler(ShopInventory shopInv);
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void onShopOpen(ShopInventory shopInv)
	{

		EmitSignal(SignalName.shopOpen, shopInv);
	}
}
