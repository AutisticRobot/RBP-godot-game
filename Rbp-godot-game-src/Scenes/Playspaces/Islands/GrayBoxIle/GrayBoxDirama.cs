using Godot;
using Godot.Collections;
using System;

public partial class GrayBoxDirama : IslandClass
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		checkAlone();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
