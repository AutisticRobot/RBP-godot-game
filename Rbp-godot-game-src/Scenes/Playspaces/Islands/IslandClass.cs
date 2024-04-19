using Godot;
using System;

public partial class IslandClass : Node2D
{
	[Export] private Node2D playerStandee;

	public virtual Vector2 GetPlayerStartPos()
	{
		return playerStandee.GlobalPosition;
	}

}
