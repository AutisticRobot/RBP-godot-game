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
		GD.Print(player.ship.dir);
		global.ShipDir = player.ship.dir;
		global.ShipPos = player.ship.GlobalPosition;
		global.playerHull = player.ship.inv;

		global.playerDataFilled = true;

		global.Player1.Merge(player.ship.save.ToData(), true);

		saveF.Save(data);

	}

	public void load()
	{
		data = (Dictionary)saveF.Load();

		if(data != null)
		{
			GD.Print("found data containing save file");
		}else{
			GD.Print("only empty save file");
			data = new();
			return;
		}

		player.ship.dir = global.ShipDir;
		player.ship.Position = global.ShipPos;
		player.ship.inv = global.playerHull;

		if(global.Player1 != null)
		{
			GD.Print("found global player data containing save file");
		player.ship.save.FromData(global.Player1);
		GD.Print(player.ship.dir);
		}else{
			GD.Print("only empty global player save file");
			return;
		}





	}

}

