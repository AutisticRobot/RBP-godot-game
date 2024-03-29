using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;

public partial class Global : Node
{
	public List<String> SceneList = new() {
		"res://Scenes/Playspaces/MainMenu.tscn",
		"res://Scenes/Playspaces/options_screen.tscn",
		"res://Scenes/Playspaces/Direamas/PlayerDierama.tscn",
		"res://Scenes/Playspaces/Maps/OceanMap.tscn",
	};

	//Save Options
	public string savePrefix = "user://saves/sav-1/";
	public SceneSave OptionsSave = new();
	public Dictionary Options = new();


	//player ship data
	public float ShipDir;//in dagrees
	public Vector2 ShipPos;
	public inventory playerHull;

	//player doll data
	public Vector2 DollPos;

	//dirAcess
	public DirAccess dir = DirAccess.Open("user://");


	public override void _Ready()
	{
		OptionsSave.global = this;
		OptionsSave.SaveFolder = "";
		OptionsSave.SaveFile = "Options.sav";

		Load();
	}

	public void Save()
	{
		Options["savPre"] = savePrefix;
		OptionsSave.Save(Options);

	}
	public void Load()
	{
		Options = (Dictionary)OptionsSave.Load();

		savePrefix = (String)Options["savPre"];
	}

	public void OpenScene(int ID)
	{
		GD.Print("Go To Scene:" + SceneList[ID]);
		GetTree().ChangeSceneToFile(SceneList[ID]);
	}

}
