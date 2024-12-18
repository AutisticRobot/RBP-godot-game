using Godot;
using System;

[GlobalClass]
public partial class MenuObj : Control
{
	[Export] public MenuObj prevMenu;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public virtual void setVisible(bool toState)
	{
		Visible  = toState;
	}

	public virtual void shutdown()
	{}
}
