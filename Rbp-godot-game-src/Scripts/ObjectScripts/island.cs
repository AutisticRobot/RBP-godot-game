using Godot;
using Godot.Collections;
using System;

public partial class island : Sprite2D
{
	[Export] public string islandID;


	public Dictionary Data;
	[Signal] public delegate Signal dockEventHandler(string IslandID);

	public void onDock()
	{
		EmitSignal(SignalName.dock, islandID);
		GD.Print("dock at island");
	}
}
