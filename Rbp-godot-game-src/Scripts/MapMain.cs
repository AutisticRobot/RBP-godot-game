using Godot;
using System;

public partial class MapMain : Node2D
{
	[Export]
	public PlayerShip playerHit;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void getLoot(LootFloat loot)
	{
		playerHit.Money   += loot.Money;
		playerHit.Food    += loot.Food;
		playerHit.Rum     += loot.Rum;
		playerHit.Linens  += loot.Linens;
		playerHit.Spices  += loot.Spices;
		playerHit.Jewlery += loot.Jewlery;
		loot.QueueFree();
	}
}
