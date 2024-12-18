using Godot;
using System;

public partial class playerLand : NPCDoll
{
			 public SceneMan manager;
	[Export] public bool paused;
	[Export] public Vector2 Acc;
	[Export] public float DecelDeltaCounterBal;
	[Export] public Vector2 Decel;
	[Export] public float clampMulti;
	public Vector2 speed;
	private Global global; 
	//[Export]
	//public Vector2 Minspeed;
	//[Export]
	//public Vector2 Maxspeed;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		global = GetNode<Global>("/root/Global");
		//Position = global.DollPos;
		Decel.X = (float)Math.Pow(Decel.X,DecelDeltaCounterBal);
		Decel.Y = (float)Math.Pow(Decel.Y,DecelDeltaCounterBal);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		base._Process(delta);
		if(!manager.pausedScene)
		{
			Pinput();

			speed.X *= (float)Math.Pow(Decel.X,delta);
			speed.Y *= (float)Math.Pow(Decel.Y,delta);

			Velocity = speed;
			MoveAndSlide();

			if(FloorDetec.HasOverlappingAreas())
			GD.Print("*Anti-Sink*");
		}

		// Save per frame
		Save();
	}

	public void Save()
	{
		global.DollPos = Position;

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
