using Godot;
using System;

public partial class sceneChanger : Sprite2D
{
	[Export]
	public string changToScene;
	[Export]
	public string text;

    public override void _Ready()
    {
		GetChild<Label>(0).Text = text;
    }

    

	public void onButtonPress()
	{
		GetTree().ChangeSceneToFile(changToScene);
	}
}
