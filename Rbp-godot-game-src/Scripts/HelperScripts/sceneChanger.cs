using Godot;
using System;

public partial class sceneChanger : Sprite2D
{
	[Export]
	public int changToSceneID;
	[Export]
	public string text;

	private Global global; 

    public override void _Ready()
    {
		global = GetNode<Global>("/root/Global");
		GetChild<Label>(0).Text = text;
    }

    

	public void onButtonPress()
	{
		global.OpenScene(changToSceneID);
	}
}
