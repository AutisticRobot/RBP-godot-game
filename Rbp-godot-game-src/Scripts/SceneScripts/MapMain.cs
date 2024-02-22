using Godot;
using Godot.Collections;
using System;

public partial class MapMain : Node2D
{
	#region RESOURCES
	[Export] public PlayerShip playerHit;
	[Export] public SceneSave saveFile;
	#endregion
	[Export] public Dictionary data;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

}
