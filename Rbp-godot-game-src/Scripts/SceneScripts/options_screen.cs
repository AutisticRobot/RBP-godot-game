using Godot;
using System;

public partial class options_screen : Node2D
{
	[Export] public string lastScene;
	[Export] public TextEdit SavePath;

	public Global global;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		global = GetNode<Global>("/root/Global");
		GetChild<sceneChanger>(0).changToScene = lastScene;
		SavePath = GetNode<TextEdit>("savePrefix");
		SavePath.Text = global.savePrefix;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		global.savePrefix = SavePath.Text;
	}
}
