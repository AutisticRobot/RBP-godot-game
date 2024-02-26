using Godot;
using System;
using System.ComponentModel;
using System.Net;

public partial class PlayerDierama : Node2D
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
		if(Input.IsActionJustPressed("ui_accept"))
		{
			if(shopMenu.Visible)
			{
				CloseShop();
			}else{
				OpenShop();
			}
		}
	}

	public void OpenShop()
	{
		//shopMenu.shop = nearShop;// uncomment this when near shop is updated;
		hud.Visible = false;
		shopMenu.Visible = true;
	}
	public void CloseShop()
	{
		hud.Visible = true;
		shopMenu.Visible = false;
	}

}
