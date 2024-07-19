using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


/*/---------------------------------------------\\\
///---------------------------------------------\\\
[[[                                             ]]]
[[[                                             ]]]
[[[                 Template Box                ]]]
[[[                                             ]]]
[[[                                             ]]]
\\\---------------------------------------------///
\\\---------------------------------------------/*/

public partial class Global : Node
{
	public List<String> SceneList = new() {
		"res://Scenes/Playspaces/MainMenu.tscn",
		"res://Scenes/Playspaces/options_screen.tscn",
		"res://Scenes/Playspaces/Direamas/PlayerDierama.tscn",
		"res://Scenes/Playspaces/Maps/OceanMap.tscn",
	};
/*/---------------------------------------------\\\
///---------------------------------------------\\\
[[[                                             ]]]
[[[                                             ]]]
[[[                 Varriables                  ]]]
[[[                                             ]]]
[[[                                             ]]]
\\\---------------------------------------------///
\\\---------------------------------------------/*/

	//Economy

	//Scene Data
	public SceneMan curSceneMan;
	public string spawnDiramaUID;
	public int lastSceneID;

	//spam open scene prevention
	private bool callRealOpenScene = false;
	private int OpenSceneID;

	//Save Options
	public string savePrefix = "user://saves/sav-1/";
	public string saveIslandFolder;
	public SceneSave OptionsSave = new();
	public Dictionary Options = new();


	//player ship data
	public bool playerDataFilled = false;
	public float ShipDir;//in dagrees
	public Vector2 ShipPos = new();
	public inventory playerHull;

	//player doll data
	public Vector2 DollPos;

	//dirAcess
	public DirAccess dir = DirAccess.Open("user://");

/*/---------------------------------------------\\\
///---------------------------------------------\\\
[[[                                             ]]]
[[[                                             ]]]
[[[            Built In Functions               ]]]
[[[                                             ]]]
[[[                                             ]]]
\\\---------------------------------------------///
\\\---------------------------------------------/*/

	public override void _Ready()
	{
		GD.Randomize();

		OptionsSave.global = this;
		OptionsSave.SaveFolder = "";
		OptionsSave.SaveFile = "Options.sav";

		Load();
	}

	public override void _Process(double delta)
	{
	//spam open scene prevention
		if(callRealOpenScene)
		{
			callRealOpenScene = false;
			RealOpenScene();
		}
	}

	public override void _Notification(int what)
	{
	    if (what == NotificationWMCloseRequest)
		{
			closeCurentScene();
	        GetTree().Quit(); // default behavior
		}
	}

/*/---------------------------------------------\\\
///---------------------------------------------\\\
[[[                                             ]]]
[[[                                             ]]]
[[[                 Save/Load                   ]]]
[[[                                             ]]]
[[[                                             ]]]
\\\---------------------------------------------///
\\\---------------------------------------------/*/

	public void Save()
	{
		Options["savPre"] = savePrefix;
		OptionsSave.Data = Options;
		OptionsSave.Save();

	}

	public void Load()
	{
		if(!OptionsSave.Exists())
		{
			Save();
		}
		Options = (Dictionary)OptionsSave.Load();

		savePrefix = (String)Options["savPre"];
	}

/*/---------------------------------------------\\\
///---------------------------------------------\\\
[[[                                             ]]]
[[[                                             ]]]
[[[             Scene Management                ]]]
[[[                                             ]]]
[[[                                             ]]]
\\\---------------------------------------------///
\\\---------------------------------------------/*/

	public void OpenScene(int ID)
	{
		lastSceneID = OpenSceneID;
		OpenSceneID = ID;
		callRealOpenScene = true;
	}
	private void RealOpenScene()
	{
			closeCurentScene();

			GD.Print("Go To Scene:" + SceneList[OpenSceneID]);
			GetTree().ChangeSceneToFile(SceneList[OpenSceneID]);

	}

	public void closeCurentScene()
	{
		if(curSceneMan != null)
		{
		curSceneMan._CloseScenePrep();
		}

	}
/*/---------------------------------------------\\\
///---------------------------------------------\\\
[[[                                             ]]]
[[[                                             ]]]
[[[                 Time Handlers               ]]]
[[[                                             ]]]
[[[                                             ]]]
\\\---------------------------------------------///
\\\---------------------------------------------/*/
//Time Data
public uint dayCounter;
public float timeOfDay;
private float dayLength = 200;





/*/---------------------------------------------\\\
///---------------------------------------------\\\
[[[                                             ]]]
[[[                                             ]]]
[[[              Economy Handlers               ]]]
[[[                                             ]]]
[[[                                             ]]]
\\\---------------------------------------------///
\\\---------------------------------------------/*/



}
