using Godot;
using System;

public partial class PlayerShip : Sprite2D
{

	[Export]
	public float speed;
	[Export]
	public float Minspeed;
	[Export]
	public float Maxspeed;
	[Export]
	public float dir;//in Dagrees

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		dir = -dir + 180;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Pinput();
        Vector2 vel = new()
        {
            X = ((float)(Math.Sin(dir * (Math.PI / 180)) * speed * delta)),
            Y = ((float)(Math.Cos(dir * (Math.PI / 180)) * speed * delta))
        };
        Position += vel;
	}

	private void Pinput()
	{
		if(Input.IsActionPressed("ui_up"))
		{
			speed += 1;
		}
		if(Input.IsActionPressed("ui_down"))
		{
			speed -= 1;
		}
		if(Input.IsActionPressed("ui_left"))
		{
			dir += 1;
		}
		if(Input.IsActionPressed("ui_right"))
		{
			dir -= 1;
		}
		Math.Clamp(speed, Minspeed, Maxspeed);
	}
}
