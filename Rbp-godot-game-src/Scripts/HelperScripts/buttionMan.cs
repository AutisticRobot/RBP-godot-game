using Godot;
using System;

public partial class buttionMan : Control
{
		 public Global global;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		global = GetNode<Global>("/root/Global");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public virtual void changeToSceneID(string ID)
	{
		global.OpenScene(ID);
	}
}
