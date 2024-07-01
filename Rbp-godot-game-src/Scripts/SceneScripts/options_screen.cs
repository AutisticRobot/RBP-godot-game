using Godot;
using System;

public partial class options_screen : SceneMan
{
	[Export] public int lastSceneID;
	[Export] public TextEdit SavePath;

	public new Global global;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScenePrep();
		global = GetNode<Global>("/root/Global");
		GetChild<buttionMan>(2).GetChild<sceneChanger>(0).changToSceneID = global.lastSceneID;
		SavePath = GetNode<TextEdit>("savePrefix");
		SavePath.Text = global.savePrefix;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void Apply()
	{
		if(!SavePath.Text.EndsWith('/')) SavePath.Text += '/';
		global.savePrefix = SavePath.Text;
		global.Save();
		global.Load();
	}

	public override void _CloseScenePrep()
	{
		
	}
}
