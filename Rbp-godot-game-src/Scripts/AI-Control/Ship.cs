using Godot;
using System;

public partial class Ship : CharacterBody2D
{

	[Export] public shipModelData data;
	[Export] public shipInput input;

	public override void _PhysicsProcess(double delta)
	{
	}
}
