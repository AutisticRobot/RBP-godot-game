using Godot;
using System;

[GlobalClass]
public partial class DockSpot : Node2D
{
	[Export] public bool isfilled;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
