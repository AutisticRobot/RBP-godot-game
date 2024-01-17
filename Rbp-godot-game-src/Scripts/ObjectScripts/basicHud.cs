using Godot;
using System;

public partial class basicHud : Control
{

	[Export]
	public PlayerShip player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		setLabelCont(0, "Gold", player.Money);
		setLabelCont(1, "Food", player.Food);
		setLabelCont(2, "Rum", player.Rum);
		setLabelCont(3, "Linens", player.Linens);
		setLabelCont(4, "Spices", player.Spices);
		setLabelCont(5, "Jewlery", player.Jewlery);
	}

	private void setLabelCont(int index, string res, int cnt)
	{
		GetChild<Label>(index).Text = res + ": " + cnt;
	}
}
