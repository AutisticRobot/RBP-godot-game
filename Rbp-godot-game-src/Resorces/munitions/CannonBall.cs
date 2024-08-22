using Godot;
using System;

public partial class CannonBall : Node2D
{
	[Export] public float Gravity = -0.1f;
	[Export] public bool ispaused = true;
	[Export] public float scaleMulti = 1;
	[Export] public float WaterDisFromCam = 100;

	public float Dir = 0;//in dagrees
	public float Speed = 0;
	[Export] public float Height = 90;
	[Export] public float VirVel = 0;//virtical velocity

	[Export] public int dammage = 1;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(!ispaused)
		{

        	Vector2 vel = new()
        	{
        	    X = (float)(Math.Sin(Dir * (Math.PI / 180)) * Speed * delta),
        	    Y = (float)(Math.Cos(Dir * (Math.PI / 180)) * Speed * delta)
        	};
			Position += vel;

			VirVel += Gravity;
			Height += VirVel;

			splashCheck();
		}

		if(Height < WaterDisFromCam)
		{
			float scale = scaleMulti / (WaterDisFromCam - Height);
			Scale = new(scale,scale);
		}else{
			Visible = false;
		}
	}

	public void splashCheck()
	{
		if(Height <= 0)
		{
			Free();
		}
	}

	public void HitObject(Node2D collObj)// damage to be handled by collited object.
	{
		Free();
	}
}
