using Godot;
using System;
using System.ComponentModel;
using System.Net;

public partial class PlayerDierama : SceneMan
{
	public ShopInventory nearShop;
	[Export] public Control hud;
	[Export] public ShopMenu shopMenu;
	[Export] public playerLand player;
	[Export] public ShipDoll shipDoll;
	[Export] public Vector2 playerSartSpot;
			 public IslandClass localIsland;
	[Export] public string IslandDiramaUID;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{	
		ScenePrep();

		localIsland = loadIslandToScene(IslandDiramaUID);
			//nearShop = GetNode<shopObject>("GrayBoxDirama/Shop0").inv;//--------------------------------------------------NEEDS TO BE CHANGED!!!!!!!!


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
