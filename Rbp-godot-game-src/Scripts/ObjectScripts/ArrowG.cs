using Godot;
using System;
using System.CodeDom.Compiler;

public partial class ArrowG : Sprite2D
{
	[Export] public float OpacityMulti = 1;

	private PlayerShip player;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetParent().GetParent<PlayerShip>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        Position = new()
        {
            X = ((float)(Math.Sin(player.ship.dir * (Math.PI / 180)))),
            Y = ((float)(Math.Cos(player.ship.dir * (Math.PI / 180))))
        };
		Rotation = (float)((-player.ship.dir + 180) * (Math.PI / 180));

		//Color Opacity = Modulate;
		//Opacity.A = Math.Clamp((player.speed*OpacityMulti)/player.Maxspeed, 0, 1);
		//Modulate = Opacity;
	}
}
