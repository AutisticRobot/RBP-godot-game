using Godot;
using System;

public partial class CannonBall : Node2D
{
	[Export] public float Gravity = 0.1f;
	[Export] public bool ispaused = true;

	public float Dir;//in dagrees
	public float Speed;
	public float Height;
	public float VirVel;//virtical velocity
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(!ispaused)
		{
			VirVel -= Gravity;
			Height -= VirVel;

			splashCheck();
		}
	}

	public void splashCheck()
	{
		if(Height <= 0)
		{
			Free();
		}
	}
}
