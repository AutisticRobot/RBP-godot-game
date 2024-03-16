using Godot;
using System;

[GlobalClass]
public partial class GroundButton : Area2D
{
	public bool PlayerOnButton = false;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void onAreaEnter(Area2D enteredBody)
	{
		if(enteredBody.Name == "PlayerArea")
		{
			PlayerOnButton = true;
		}
	}
	public void onAreaExit(Area2D enteredBody)
	{
		if(enteredBody.Name == "PlayerArea")
		{
			PlayerOnButton = false;
		}
	}
}
