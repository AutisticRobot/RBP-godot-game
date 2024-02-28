using Godot;
using Godot.Collections;
using System;

public partial class MapMain : Node2D
{
	#region RESOURCES
	[Export] public PlayerShip player;
	[Export] public SceneSave saveFile;
	#endregion
	[Export] public Dictionary data;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		saveFile.global = GetNode<Global>("/root/Global");
		data = (Dictionary)saveFile.Load();
		player.Position = (Vector2)data["shipPos"];
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("ui_accept"))
		{
			data["shipPos"] = player.Position;
			saveFile.Save(data);
		}
	}

}
