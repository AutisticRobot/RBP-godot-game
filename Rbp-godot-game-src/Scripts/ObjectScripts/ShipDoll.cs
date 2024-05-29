using Godot;
using System;

public partial class ShipDoll : Node2D
{
	[Export] public inventory inv;
	[Export] public int targeSceneID;


	private Global global; 
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		global = GetNode<Global>("/root/Global");
		if(global.playerHull != null)
		{
			inv = global.playerHull;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void closeShip()
	{
		global.playerHull = inv;
		GD.Print("close shop" + inv[0].count);
	}

	public void onPress()
	{
		GD.Print("Open Seaseme!");

		global.OpenScene(targeSceneID);
	}
}
