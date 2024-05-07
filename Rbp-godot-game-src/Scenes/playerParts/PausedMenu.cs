using Godot;
using System;

public partial class PausedMenu : Control
{
	[Export] public SceneMan parent;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	
	}

	public void interactMenu()
	{
		if(Visible)
		{
			closeMenu();
		}else{
			openMenu();
		}
	}

	public void openMenu()
	{
		parent.pausedScene = true;
		Visible = true;
	}
	public void closeMenu()
	{
		parent.pausedScene = false;
		Visible = false;

	}
}
