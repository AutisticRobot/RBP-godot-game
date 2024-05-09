using Godot;
using System;

public partial class sceneChanger : Sprite2D
{
	[Export] public int changToSceneID;
	[Export] public string text;

	[Export] private buttionMan manager; 

	public override void _Ready()
	{
		GetChild<Label>(0).Text = text;
	}

	

	public void onButtonPress()
	{
		manager.changeToSceneID(changToSceneID);
	}
}
