using Godot;
using Godot.Collections;
using System;

public partial class GrayBoxDirama : IslandClass
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		hideStandee();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public override void Save()
	{
		fileSave.Data = new();
		fileSave.Data["shops"] = ShopManLocal.getShposSaveData();

		fileSave.Save();

	}
	public override void Load()
	{
		fileSave.Load();
		GD.Print(fileSave.Data);
		ShopManLocal.loadShopsSaveData((Dictionary)fileSave.Data["shops"]);
	}
}
