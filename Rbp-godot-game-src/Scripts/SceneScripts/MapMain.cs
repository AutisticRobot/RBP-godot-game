using Godot;
using Godot.Collections;
using System;

public partial class MapMain : SceneMan
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
		if((Dictionary)data["shipinv"] != null)
		{
			Dictionary temp = (Dictionary)data["shipinv"];
			player.inv[0] = (int)temp[0];
			player.inv[1] = (int)temp[1];
			player.inv[2] = (int)temp[2];
			player.inv[3] = (int)temp[3];
			player.inv[4] = (int)temp[4];
			player.inv[5] = (int)temp[5];
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("ui_accept"))
		{
			data["shipPos"] = player.Position;
			data["shipinv"] = player.inv.ToDic();
			saveFile.Save(data);
		}
	}

	public override void _CloseScenePrep()
	{
		
	}

}
