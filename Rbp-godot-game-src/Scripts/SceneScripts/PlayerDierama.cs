using Godot;
using System;
using System.ComponentModel;
using System.Net;

public partial class PlayerDierama : SceneMan
{
	[Export] public string islandSaveFolder;
	//[Export] public Control hud;
	[Export] public MenuHandler Menus;
			 public PausedMenu pauseMenu;
			 public ShopMenu shopMenu;
	[Export] public playerLand player;
	[Export] public ShipDoll shipDoll;
	[Export] public Vector2 playerSartSpot;
			 public IslandClass localIsland;
			 public string IslandDiramaUID;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		ScenePrep();
		player.manager = this;
		IslandDiramaUID = global.spawnDiramaUID;

		localIsland = loadIslandToScene(IslandDiramaUID);
		localIsland.fileSave.global = global;
		islandSaveFolder = "islands/";
		localIsland.fileSave.SaveFolder = islandSaveFolder;
		localIsland.prepIsland();

		//localIsland.shopOpen += (shop) => {OpenShop(shop);};
		localIsland.Connect("shopOpen", new Callable(this, MethodName.OpenShop));
		//Get Menus
		pauseMenu = (PausedMenu)Menus.MenusList[0];
		shopMenu = (ShopMenu)Menus.MenusList[1];


		playerSartSpot = localIsland.GetPlayerStartPos();

		player.Position = playerSartSpot;

		shipDoll.Position = localIsland.GetDockingPos();

		shopMenu.player = shipDoll;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		InputHandler();
	}

	public void OpenShop(ShopInventory shopInv)
	{
		shopMenu.shop = shopInv;
		//hud.Visible = false;
		Menus.OpenMenu(shopMenu);
	}
	public override void OpenMenu(MenuObj menu)
	{
		pausedScene = true;

	}
	public override void CloseMenu()
	{
		//hud.Visible = true;
		Menus.Visible = false;
		pausedScene = false;
	}

	private void InputHandler()
	{
		if(Input.IsActionJustPressed("enterMenu"))
		{
			Menus.BackPress();
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
		localIsland.shutDown();
		shipDoll.closeShip();
		
	}



}
