using Godot;
using System;

public partial class island : Sprite2D
{
	[Export]
	public int Money;
	[Export]
	public int Rum;
	[Export]
	public int Linens;
	[Export]
	public int Spices;
	[Export]
	public int Jewlery;
	[Export]
	public int FoodPrice;
	[Export]
	public int RumPrice;
	[Export]
	public int LinensPrice;
	[Export]
	public int SpicesPrice;
	[Export]
	public int JewleryPrice;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
