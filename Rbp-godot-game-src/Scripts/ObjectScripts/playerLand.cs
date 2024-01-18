using Godot;
using System;

public partial class playerLand : Node2D
{
	[Export]
	public Vector2 Acc;
	public Vector2 speed;
	[Export]
	public Vector2 Minspeed;
	[Export]
	public Vector2 Maxspeed;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Pinput();

		Position += speed;
	}


	private void Pinput()
	{
		if(Input.IsActionPressed("ui_up"))
		{
			speed.Y -= Acc.Y;
		}
		if(Input.IsActionPressed("ui_down"))
		{
			speed.Y += Acc.Y;
		}
		if(Input.IsActionPressed("ui_left"))
		{
			speed.X -= Acc.X;
		}
		if(Input.IsActionPressed("ui_right"))
		{
			speed.X += Acc.X;
		}
		speed.Y = Math.Clamp(speed.Y, Minspeed.Y, Maxspeed.Y);
		speed.X = Math.Clamp(speed.X, Minspeed.X, Maxspeed.X);
	}
}
