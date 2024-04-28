using Godot;
using System;
using System.ComponentModel;
using System.Net;

public partial class PlayerDierama : SceneMan
{
	[Export] public Control hud;
	[Export] public ShopMenu shopMenu;
	[Export] public playerLand player;
	[Export] public ShipDoll shipDoll;
	[Export] public Vector2 playerSartSpot;
			 public IslandClass localIsland;
			 public string IslandDiramaUID;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{	
		ScenePrep();
		IslandDiramaUID = global.spawnDiramaUID;

		localIsland = loadIslandToScene(IslandDiramaUID);

		//localIsland.shopOpen += (shop) => {OpenShop(shop);};
		localIsland.Connect("shopOpen", new Callable(this, MethodName.OpenShop));


		playerSartSpot = localIsland.GetPlayerStartPos();

		player.Position = playerSartSpot;

		shipDoll.Position = localIsland.GetDockingPos();


	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		InputHandler();
	}

	public void OpenShop(ShopInventory shopInv)
	{
		shopMenu.shop = shopInv;
		hud.Visible = false;
		shopMenu.Visible = true;
	}
	public void CloseShop()
	{
		hud.Visible = true;
		shopMenu.Visible = false;
	}

	private void InputHandler()
	{
		if(Input.IsActionJustPressed("enterMenu"))
		{
			if(shopMenu.Visible)
			{
				CloseShop();
			}else{
				GetTree().ChangeSceneToFile("res://Scenes/Playspaces/options_screen.tscn");
			}
		}

	}

	public IslandClass loadIslandToScene(string IslandSceneUID)
	{
		string IslandPath = ResourceUid.GetIdPath(ResourceUid.TextToId(IslandDiramaUID));

		Node Island = ResourceLoader.Load<PackedScene>(IslandPath).Instantiate();

		AddChild(Island);

		GD.Print("Island Loaded");
		GD.Print(Island.Name);

		return (IslandClass)Island;
	}


	public override void _CloseScenePrep()
	{
		
	}



}
