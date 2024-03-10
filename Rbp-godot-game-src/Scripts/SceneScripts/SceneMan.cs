using Godot;
using System;

[GlobalClass]
public partial class SceneMan : Node2D
{
	[Export] public SceneSave save;

	public Global global;
	// Called when the node enters the scene tree for the first time.
	public void ScenePrep()
	{
		global = GetNode<Global>("/root/Global");
		save.global = global;
	}

	extern public void _CloseScenePrep();
}
