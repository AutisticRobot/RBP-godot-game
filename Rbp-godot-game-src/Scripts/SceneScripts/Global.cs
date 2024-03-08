using Godot;
using Godot.Collections;
using System;

public partial class Global : Node
{
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

}
