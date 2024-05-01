using Godot;
using System;

[GlobalClass]
public partial class IslandClass : Node2D
{
	[Export] private Node2D playerStandee;
	[Export] private portCaptain PortCaptainLocal;
	[Signal] public delegate Signal shopOpenEventHandler(ShopInventory shopInv);
	[Export] public string SaveFileName;
			 public SceneSave fileSave = new();

	public virtual void prepIsland()
	{
		fileSave.SaveFile = SaveFileName;
		Load();

	}

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


	public virtual void Save(){GD.Print("save function not used in " + Name);}
	public virtual void Load(){GD.Print("load function not used in " + Name);}

}
