using Godot;
using System;

public partial class QuitButton : Sprite2D
{
	[Export] public string text;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public override void _Ready()
	{
		GetChild<Label>(0).Text = text;
	}

	

	public void onButtonPress()
	{
		GetTree().Root.PropagateNotification((int)NotificationWMCloseRequest);
	}
}
