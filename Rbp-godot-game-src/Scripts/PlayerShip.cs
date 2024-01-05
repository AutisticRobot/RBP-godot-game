using Godot;
using System;

public partial class PlayerShip : Sprite2D
{

	[Export]
	public float speed;
	[Export]
	public float dir;//in Dagrees

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
