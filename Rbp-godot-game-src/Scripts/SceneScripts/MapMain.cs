using System.Linq;
using Godot;
using Godot.Collections;

public partial class MapMain : SceneMan
{
	#region RESOURCES
	[Export] public PlayerShip player;

	#endregion
	[Export] public Dictionary data = new();
	[Export] public PausedMenu pauseMenu;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScenePrep();
		
		player.preLoad(this);

		load();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("Save"))
		{
			save();
		}

		if(Input.IsActionJustPressed("enterMenu"))
		{
			global.OpenScene("rbp:options");
			// <=========================================================================[Put open menu code here
		}
	}

	public override void _CloseScenePrep()
	{
		save();
		
	}

	public void playerDock(string IslandID)
	{
		global.OpenScene("rbp:dirama");
		global.spawnDiramaUID = IslandID;
	}

	public void save()
	{
		global.ShipDir = player.ship.dir;
		global.ShipPos = player.ship.GlobalPosition;
		global.playerHull = player.ship.inv;

		global.playerDataFilled = true;

		saveF.Save(data);

	}

	public void load()
	{
		data = (Dictionary)saveF.Load();


		player.ship.dir = global.ShipDir;
		player.Position = global.ShipPos;
		player.ship.inv = global.playerHull;

		if(data != null)
		{
			GD.Print("found data containing save file");

		}else{
			GD.Print("only empty save file");
			data = new();
		}




	}

}

