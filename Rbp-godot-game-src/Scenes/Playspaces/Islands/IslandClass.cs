using Godot;
using System;

[GlobalClass]
public partial class IslandClass : Node2D
{
	[Export] private Node2D playerStandee;
	[Export] private portCaptain PortCaptainLocal;
	[Signal] public delegate Signal shopOpenEventHandler(ShopInventory shopInv);

	public virtual Vector2 GetPlayerStartPos()
	{
		return playerStandee.GlobalPosition;

	}

	public virtual Vector2 GetDockingPos()
	{
		return PortCaptainLocal.getRandDock().Position;
	}

	public virtual void hideStandee()
	{
		playerStandee.Visible = false;
	}

	public virtual void onShopOpen(ShopInventory shopInv)
	{

		EmitSignal(SignalName.shopOpen, shopInv);
	}

}
