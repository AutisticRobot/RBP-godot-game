using Godot;
using System;

public partial class Test : Node
{
	public int testInt1;
	[Export]
	public int testInt2;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
