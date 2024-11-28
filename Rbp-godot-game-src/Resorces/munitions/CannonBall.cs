using Godot;
using System;

public partial class CannonBall : Node2D
{
	[Export] public MunitionRes Specs;

	public float Dir = 0;//in dagrees
	public float Speed = 0;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		if(!Specs.ispaused)
		{

        	Vector2 vel = new()
        	{
        	    X = (float)(Math.Sin(Dir * (Math.PI / 180)) * Speed * delta),
        	    Y = (float)(Math.Cos(Dir * (Math.PI / 180)) * Speed * delta)
        	};
			Position += vel;

			Specs.VirVel += Specs.Gravity;
			Specs.Height += Specs.VirVel;

			splashCheck();
		}

		if(Specs.Height < Specs.WaterDisFromCam)
		{
			float scale = Specs.scaleMulti / (Specs.WaterDisFromCam - Specs.Height);
			Scale = new(scale,scale);
		}else{
			Visible = false;
		}

	}

	public void preLoad()
	{
		if(Specs.Height < Specs.WaterDisFromCam)
		{
			float scale = Specs.scaleMulti / (Specs.WaterDisFromCam - Specs.Height);
			Scale = new(scale,scale);
		}else{
			Visible = false;
		}
	}

	public void splashCheck()
	{
		if(Specs.Height <= 0)
		{
			GD.Print("cannon shot hit water");
			QueueFree();
		}
	}

	public void HitObject(Node2D collObj)// damage to be handled by collited object.
	{
		if(Specs.Height > (Specs.WaterDisFromCam - Specs.shipHitHeight))
		{
			GD.Print("cannon shot hit object");
			QueueFree();
		}
	}
}
