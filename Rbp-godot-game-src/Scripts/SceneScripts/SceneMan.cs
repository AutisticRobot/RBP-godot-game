using Godot;
using System;
using System.Runtime.InteropServices;

[GlobalClass]
public partial class SceneMan : Node2D
{
	[Export] public SceneSave saveF;
	public string IslandDiramaUID;

	public Global global;
	// Called when the node enters the scene tree for the first time.
	public void ScenePrep()
	{
		global = GetNode<Global>("/root/Global");
		IslandDiramaUID = global.spawnDiramaUID;
		saveF.global = global;
		global.curSceneMan = this;
	}

	public virtual void _CloseScenePrep() {}
}
