using System;
using Godot;

[GlobalClass]
public partial class IslandClass : Node2D
{
	[Export] public Node2D playerStandee;
	[Export] public portCaptain PortCaptainLocal;
	[Export] public shopMan ShopManLocal;
	[Signal] public delegate Signal shopOpenEventHandler(ShopInventory shopInv);
	[Export] public string SaveFileName;
			 public SceneSave fileSave = new();

	public virtual void prepIsland()
	{
		fileSave.SaveFile = SaveFileName;
		try
		{
		Load();
		}catch(Exception e){
			GD.PrintRich("[color=red][b]Error Loading " + Name + ", " + e.ToString() + "[/b][/color]");
		}

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

	public virtual void shutDown()
	{
		Save();

	}


	public virtual void Save(){GD.Print("save function not used in " + Name);}
	public virtual void Load(){GD.Print("load function not used in " + Name);}

}
