using Godot;
using System;

public partial class IslandClass : Node2D
{
	[Export] private Node2D playerStandee;
	[Export] private portCaptain PortCaptainLocal;

	public virtual Vector2 GetPlayerStartPos()
	{
		return playerStandee.GlobalPosition;

	}

	public virtual Vector2 GetDockingPos()
	{
		return PortCaptainLocal.getRandDock().Position;
	}

	public void hideStandee()
	{
		playerStandee.Visible = false;
	}


}
