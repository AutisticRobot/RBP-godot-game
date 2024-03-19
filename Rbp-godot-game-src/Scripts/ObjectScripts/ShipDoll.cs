using Godot;
using System;

public partial class ShipDoll : Node2D
{
	[Export]
	public inventory inv;


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
		global.playerHull = inv;//this should use signals for the sake of expanability and performance;
	}

	public void onPress()
	{
		GD.Print("Open Seaseme!");
	}
}
