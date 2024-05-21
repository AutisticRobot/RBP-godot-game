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
			// <=========================================================================[Put open menu code here
		}
	}

	public override void _CloseScenePrep()
	{
		save();
		
	}

	public void playerDock(string IslandID)
	{
		global.OpenScene(2);
		global.spawnDiramaUID = IslandID;
	}

	public void save()
	{
			data["shipPos"] = player.Position;
			data["shipinv"] = player.inv.ToDic();
			saveF.Save(data);

	}

	public void load()
	{
		data = (Dictionary)saveF.Load();

		if(data != null)
		{
			GD.Print("found data containing save file");
			player.Position = (Vector2)data["shipPos"];
			player.inv.FromDic((Dictionary)data["shipinv"]);
			global.playerHull = player.inv;

		}else{
			GD.Print("only empty save file");
			data = new();
		}




	}

}

