using Godot;
using System;

public partial class NavMan : Node2D
{
	[Export] public Node2D PlayerShip;
			 public SceneMan manager;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		manager = GetOwner<SceneMan>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
