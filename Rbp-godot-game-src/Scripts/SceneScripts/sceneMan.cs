using Godot;
using System;

public partial class sceneMan : Node2D
{
	[Export] public SceneSave save;

	public Global global;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		global = GetNode<Global>("/root/Global");
		save.global = global;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
