using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;


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

/*/---------------------------------------------\\\
///---------------------------------------------\\\
[[[                                             ]]]
[[[                                             ]]]
[[[                 Varriables                  ]]]
[[[                                             ]]]
[[[                                             ]]]
\\\---------------------------------------------///
\\\---------------------------------------------/*/

	//Mod Data
	public modLoader modLoader = new();
	public almanac almanac = new();

	//Enitty data
	public IDCord IDCordinator = new();
	public System.Collections.Generic.Dictionary<string, diramaObjIns> diramaEntitys;

	//Economy

	//Scene Data
	public SceneMan curSceneMan;
	public string spawnDiramaUID;
	public string lastSceneID;

	//spam open scene prevention
	private bool callRealOpenScene = false;
	private string OpenSceneID;

	//Save Options
	public string savePrefix = "user://saves/sav-1/";
	public string saveIslandFolder;
	public SceneSave OptionsSave = new();
	public Dictionary Options = new();


	//player ship data
	public Dictionary PlayerData = new();
	public Dictionary Player1;
	public string curShipID;
	public SaveMan PlayerSaveMan = new();
	public SceneSave PlayerSaveFile = new();
	public bool playerDataFilled = false;
	public float ShipDir;//in dagrees
	public Vector2 ShipPos = new();
	public inventory playerHull = new();

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

		LoadPlayer();
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
            try
            {
				closeCurentScene();
				SavePlayer();
			}catch(SystemException e){
				GD.PushError("Could not close current scene. Shuting down anyway...\n", e);
			}
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

	public void autoSave()//intented to be a reduced save for autosaving.
	{
		Save();
	}

	//Player save/load

	public void SavePlayer()
	{
		fillPlayerSaveObject();

		Player1 ??= new();
		PlayerData ??= new();

		PlayerData.Merge(PlayerSaveMan.Encode(), true);
		PlayerData.Merge(Player1, true);
		PlayerSaveFile.Save(Json.Stringify(PlayerData));
		GD.Print("Save data" + PlayerSaveMan.Encode());

/*
			data["shipPos"] = ShipPos;
			data["shipDir"] = ShipDir;
			data["shipinv"] = playerHull.ToData();
			PlayerSaveFile.Save(data);
		*/

	}

	public void LoadPlayer()
	{
		fillPlayerSaveObject();
		string data = (string)PlayerSaveFile.Load();
		GD.Print("data:" + data);
		if(data.Length >= 8)
		{
			PlayerSaveMan.Decode((Dictionary)Json.ParseString(data));

			PlayerSaveMan.decodedData ??= new();
			PlayerData.Merge(PlayerSaveMan.decodedData, true);
			if(PlayerData.ContainsKey("001"))
			{
				Player1 ??= new();
				Player1.Merge((Dictionary)Json.ParseString((string)PlayerData["001"]), true);
				inventory inv = new();
				inv.FromData(Player1["inv"]);
				GD.Print((string)inv);
			}else{
				GD.Print("no 001 id in save");
				GD.Print(PlayerSaveMan.decodedData);
			}
		}
/*
		Dictionary data = (Dictionary)PlayerSaveFile.Load();
		ShipPos = (Vector2)data["shipPos"];
		ShipDir = (float)data["shipDir"];
		playerHull.FromData(data["shipinv"]);
		*/
	}

	public void fillPlayerSaveObject()
	{
		PlayerSaveFile.global = this;
		PlayerSaveFile.SaveFile = "Player.sav";
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

	public void OpenScene(string ID)
	{
		lastSceneID = OpenSceneID;
		OpenSceneID = ID;
		callRealOpenScene = true;
	}
	private void RealOpenScene()
	{
		SavePlayer();
		PlayerSaveMan.RemoveToBeSaved("001");

		closeCurentScene();

		GD.Print("Go To Scene: " + almanac.SceneDir[OpenSceneID]);
		GetTree().ChangeSceneToFile(almanac.SceneDir[OpenSceneID]);

	}

	public void closeCurentScene()
	{
		if(curSceneMan != null)
		{
		curSceneMan._CloseScenePrep();
		autoSave();
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


/*/---------------------------------------------\\\
///---------------------------------------------\\\
[[[                                             ]]]
[[[                                             ]]]
[[[                     Math                    ]]]
[[[                                             ]]]
[[[                                             ]]]
\\\---------------------------------------------///
\\\---------------------------------------------/*/

    public static float Vec2toDir(Vector2 target)
    {
        return (float)(Math.Atan2(-target.X, -target.Y) * (180/Math.PI)) + 180;
    }

}
