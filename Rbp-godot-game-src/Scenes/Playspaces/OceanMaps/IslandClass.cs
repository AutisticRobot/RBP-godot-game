using System;
using Godot;
using Godot.Collections;

[GlobalClass]
public partial class IslandClass : Node2D
{
			 public bool isIsland = true;
	[Export] public string diramaUID;//     I Need to find if this is already accesable elseware
	[Export] public Node2D playerStandee;
	[Export] public portCaptain PortCaptainLocal;
	[Export] public shopMan ShopManLocal;
	[Signal] public delegate Signal shopOpenEventHandler(ShopInventory shopInv);
	[Export] public string SaveFileName;
			 public SceneSave fileSave = new();


	public override void _Ready()
	{
		checkAlone();
	}


	public void checkAlone()
	{
		try
		{
			GD.Print(GetTree().Root.GetChild<IslandClass>(1).isIsland);
			GD.Print("Island Is Alone");
			openSelfInDirama();
		}catch{
			GD.Print("Is Alone Fail: " + GetTree().Root.GetChild<Node>(1).Name);
		}
	}
	public void openSelfInDirama()
	{
		Global global = GetNode<Global>("/root/Global");
			global.OpenScene("rbp:dirama");
			global.spawnDiramaUID = diramaUID;
	}

	public virtual void prepIsland()
	{
		hideStandee();
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

	public virtual DockSpot GetDock()
	{
		return PortCaptainLocal.getRandDock();
	}

	public virtual void hideStandee()
	{
		playerStandee.Visible = false;
	}

	public virtual void onShopOpen(ShopInventory shopInv)
	{

		EmitSignal(SignalName.shopOpen, shopInv);
		ShopManLocal.modShopData();
	}

	public virtual void shutDown()
	{
		Save();

	}


	public virtual void Save()
	{
		fileSave.Data = new();
		fileSave.Data["shops"] = ShopManLocal.getShposSaveData();
		fileSave.Save();
	}
	public virtual void Load()
	{
		if(fileSave.Exists())
		{
			GD.Print("island Class loaded a file: " + fileSave.SaveFile);

			fileSave.Load();
			ShopManLocal.loadShopsSaveData((Dictionary)fileSave.Data["shops"]);
		}
	}

}
