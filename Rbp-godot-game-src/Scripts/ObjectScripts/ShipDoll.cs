using Godot;
using System;

public partial class ShipDoll : Node2D
{
	[Export] public inventory inv;
	[Export] public string targeSceneID;
			 public DockSpot DockSpot;


	private Global global; 
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		global = GetNode<Global>("/root/Global");
		if(global.playerDataFilled && global.PlayerData.ContainsKey("inv"))
		{
			GD.Print(global.PlayerData);
			inv.FromData(global.PlayerData["inv"]);
			GD.Print(global.PlayerData["inv"]);
			GD.Print("found player inventory" + inv);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void closeShip()
	{
		global.PlayerData["inv"] = inv.ToData();
		GD.Print("close ship");
	}

	public void onPress()
	{
		GD.Print("Open Seaseme!");

		global.OpenScene(targeSceneID);
	}

	public void DockAt(DockSpot newDock)
	{
		DockSpot = newDock;
		Dock();
	}

	public void Dock()
	{
		Position = DockSpot.Position;
		Rotation = DockSpot.Rotation;

		DockSpot.isfilled = true;
	}
}
