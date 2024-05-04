using Godot;
using System;

[GlobalClass]
public partial class GroundButton : Area2D
{
	[Signal] public delegate Signal buttonPressedEventHandler();

	public bool PlayerOnButton = false;
	[Export] public string inputInteract = "interact";
	public Global global;

	//temp fix for scene Change crash
	public double colldown = 1.5;

	
	public override void _Ready()
	{
		global = GetNode<Global>("/root/Global");
		AreaEntered += onAreaEnter;
		AreaExited += onAreaExit;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed(inputInteract) && PlayerOnButton && global.buttonColldown <= 0)
		{
			GD.Print("Ground Button Pressed");
			global.buttonColldown += colldown;
			EmitSignal(SignalName.buttonPressed);
		}
	}

	public void onAreaEnter(Area2D enteredBody)
	{
		if(true)//enteredBody.Name == TargetName)
		{
			PlayerOnButton = true;
		}
	}
	public void onAreaExit(Area2D enteredBody)
	{
		if(true)//enteredBody.Name == TargetName)
		{
			PlayerOnButton = false;
		}
	}
}
