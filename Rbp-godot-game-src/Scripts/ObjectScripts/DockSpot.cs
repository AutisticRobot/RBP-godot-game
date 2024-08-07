using Godot;
using System;

[GlobalClass]
public partial class DockSpot : Node2D
{
	[Export] public bool isfilled;
	[Export] public Node2D Bridge;
	[Export] public StaticBody2D DockPlug;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Bridge.Visible = isfilled;

		if(isfilled)
		{
			DockPlug.CollisionLayer = 0;
		}else{
			DockPlug.CollisionLayer = 16;
		}
			DockPlug.Visible = !isfilled;
	}
}
