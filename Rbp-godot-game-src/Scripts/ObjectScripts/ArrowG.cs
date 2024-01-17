using Godot;
using System;
using System.CodeDom.Compiler;

public partial class ArrowG : Sprite2D
{
	[Export]
	public int Distance;

	private PlayerShip player;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetParent<PlayerShip>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        Position = new()
        {
            X = ((float)(Math.Sin(player.dir * (Math.PI / 180)) * Distance)),
            Y = ((float)(Math.Cos(player.dir * (Math.PI / 180)) * Distance))
        };
		Rotation = (float)((-player.dir + 180) * (Math.PI / 180));
	}
}
