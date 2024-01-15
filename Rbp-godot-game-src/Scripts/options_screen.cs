using Godot;
using System;

public partial class options_screen : Node2D
{
	[Export]
	public PackedScene lastScene;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetChild<sceneChanger>(0).changToScene = lastScene;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
