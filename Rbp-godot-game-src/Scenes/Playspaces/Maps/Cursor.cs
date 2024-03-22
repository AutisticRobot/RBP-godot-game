using Godot;
using System;

public partial class Cursor : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position = GetViewport().GetMousePosition() * new Vector2(10,10);
	}
}
