using Godot;
using System;

public partial class LootFloat : Sprite2D
{
	[Export]
	public int Money;
	[Export]
	public int Food;
	[Export]
	public int Rum;
	[Export]
	public int Linens;
	[Export]
	public int Spices;
	[Export]
	public int Jewlery;



	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _pickedUp(Area2D tmp)
	{
		EmitSignal(SignalName.PickedLoot, this);
	}

	[Signal]
	public delegate void PickedLootEventHandler(LootFloat loot);
}
