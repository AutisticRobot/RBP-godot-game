using Godot;
using System;
using System.ComponentModel;
using System.Net;

public partial class PlayerDierama : SceneMan
{
	public ShopInventory nearShop;
	[Export] public Control hud;
	[Export] public ShopMenu shopMenu;
	[Export] public SceneSave saveFile;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		nearShop = GetNode<shopObject>("GrayBoxDirama/Shop0").inv;
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


	public override void _CloseScenePrep()
	{
		
	}



}
