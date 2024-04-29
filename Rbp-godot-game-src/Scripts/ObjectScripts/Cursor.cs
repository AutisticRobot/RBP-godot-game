using Godot;
using System;

public partial class Cursor : Sprite2D
{
	[Export] public NavMan nav;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(!nav.manager.pausedScene)
		{
			if(Input.IsActionPressed("L-click"))
			{
				Position = GetGlobalMousePosition();
			}
		}
	}
}
