using Godot;
using System;

public partial class IslandClass : Node2D
{
	[Export] public Sprite2D playerStandee;

	public virtual Vector2 GetPlayerStartPos()
	{
		return playerStandee.Position;
	}

}
