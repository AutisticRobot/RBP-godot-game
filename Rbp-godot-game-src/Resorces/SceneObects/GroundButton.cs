using Godot;
using System;

[GlobalClass]
public partial class GroundButton : Area2D
{
	[Signal] public delegate Signal buttonPressedEventHandler();

	public bool PlayerOnButton = false;
	public string inputInteract = "interact";

	
	public override void _Ready()
	{
		AreaEntered += onAreaEnter;
		AreaExited += onAreaExit;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed(inputInteract) && PlayerOnButton)
		{
			EmitSignal(SignalName.buttonPressed);
			GD.Print("Ground Button Pressed");
		}
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
