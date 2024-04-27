using Godot;
using Godot.Collections;
using System;

public partial class island : Sprite2D
{
	[Export] public string diramaUID;


	public Dictionary Data;
	[Signal] public delegate Signal dockEventHandler(string IslandID);

	public void onDock()
	{
		EmitSignal(SignalName.dock, diramaUID);
		GD.Print("dock at island");
	}
}
