using Godot;
using System;

public partial class PausedMenu : MenuObj
{
	[Export] public CanvasLayer buttions;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		buttions.Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	
	}



	public override void setVisible(bool toState)
	{
		GD.Print("pauseMenu = " + toState);
		buttions.Visible = toState;
		Visible = toState;
	}
}
