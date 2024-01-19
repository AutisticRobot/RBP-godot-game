using Godot;
using System;

public partial class playerLand : Node2D
{
	[Export]
	public Vector2 Acc;
	[Export]
	public float DecelDeltaCounterBal;
	[Export]
	public Vector2 Decel;
	[Export]
	public float clampMulti;
	public Vector2 speed;
	//[Export]
	//public Vector2 Minspeed;
	//[Export]
	//public Vector2 Maxspeed;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Decel.X = (float)Math.Pow(Decel.X,DecelDeltaCounterBal);
		Decel.Y = (float)Math.Pow(Decel.Y,DecelDeltaCounterBal);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Pinput();

		Vector2 DeltaModifiedSpeed = new Vector2(
		speed.X * (float)delta,
		speed.Y * (float)delta
		);

		Position += DeltaModifiedSpeed;
		speed.X *= (float)Math.Pow(Decel.X,delta);
		speed.Y *= (float)Math.Pow(Decel.Y,delta);
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
		speed.Y = Math.Clamp(speed.Y, -(Acc.Y * clampMulti), (Acc.Y * clampMulti));
		speed.X = Math.Clamp(speed.X, -(Acc.X * clampMulti), (Acc.X * clampMulti));
	}
}
