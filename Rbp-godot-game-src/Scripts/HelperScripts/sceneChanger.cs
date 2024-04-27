using Godot;
using System;

public partial class sceneChanger : Sprite2D
{
	[Export] public int changToSceneID;
	[Export] public string text;

	private SceneMan manager; 

	public override void _Ready()
	{
		manager = GetOwner<SceneMan>();
		GetChild<Label>(0).Text = text;
	}

	

	public void onButtonPress()
	{
		manager.changeToSceneID(changToSceneID);
	}
}
